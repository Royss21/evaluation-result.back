﻿
namespace Application.Main.Services.EvaResult
{
    using Application.Dto.Employee.Collaborator;
    using Application.Dto.EvaResult.Evaluation;
    using Application.Dto.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.PrimeNg;
    using Application.Main.Service.Base;
    using Application.Main.Services.EvaResult.Interfaces;
    using Domain.Common.Constants;
    using Domain.Main.Config;
    using Domain.Main.Employee;
    using Domain.Main.EvaResult;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EvaluationService : BaseService, IEvaluationService
    {
        public EvaluationService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<EvaluationDto> CreateAsync(EvaluationCreateDto request)
        {
            if (!request.EvaluationComponentsDto.Any())
                throw new WarningException("No hay ningun componente seleccionado para la evaluacion.");

            if (request.EvaluationComponentsDto.Any(ec => ec.ComponentId == GeneralConstants.Component.Competencies) && !request.ComponentStagesDto.Any())
                throw new WarningException("No seleccionado las etapas del componente de COMPETENCIAS");

            var evaluation = _mapper.Map<Evaluation>(request);
            if (!request.IsEvaluationTest)
            {
                var countEvaluations = await CountEvaluationsCurrentPeriod();
                var countEvaluationsConfig = await CountEvaluationByPeriodConfig();

                if (countEvaluations == countEvaluationsConfig)
                    throw new WarningException($"Llegó al limite de {countEvaluationsConfig} evaluaciones por periodo");
            }

            var currentDate = DateTime.UtcNow.GetDatePeru();
            evaluation.StatusId = request.IsEvaluationTest
                                        ? GeneralConstants.StatusGenerals.Test
                                        : currentDate.RangeDateBetween(evaluation.StartDate, evaluation.EndDate)
                                            ? GeneralConstants.StatusGenerals.InProgress
                                            : GeneralConstants.StatusGenerals.Create;

            var evaluationComponents = _mapper.Map<List<EvaluationComponent>>(request.EvaluationComponentsDto);
            evaluationComponents.ForEach(ec => {

                if (ec.ComponentId == GeneralConstants.Component.Competencies)
                {
                    var componentStages = _mapper.Map<List<ComponentStage>>(request.ComponentStagesDto);
                    componentStages.ForEach(cs => cs.EvaluationComponentId = ec.Id);
                    ec.ComponentStages = componentStages;
                }

                ec.StatusId = GeneralConstants.StatusGenerals.Create;
            });

            evaluation.EvaluationComponents = evaluationComponents;
            evaluation.EvaluationCollaborators = await RegisterCollaboratorsInEvaluation(currentDate);

            var dataConfigurations = await GetDataCurrentConfiguration(evaluationComponents.Select(ce => ce.ComponentId).ToList());
            foreach (var evaluationComponent in evaluation.EvaluationComponents)
            {
                var hierarchiesComponent = dataConfigurations.Item1;
                var subcomponents = dataConfigurations.Item2;
                var conducts = new List<Conduct>();
                var levels = new List<Level>();

                hierarchiesComponent = hierarchiesComponent.Where(s => s.ComponentId == evaluationComponent.ComponentId).ToList();
                subcomponents = subcomponents.Where(s => s.ComponentId == evaluationComponent.ComponentId).ToList();

                if (!hierarchiesComponent.Any())
                    throw new WarningException($"No se ha configurado el peso de las jerarquias para el componente de {GeneralConstants.Component.NameComponents[evaluationComponent.ComponentId]}");

                if (!subcomponents.Any())
                    throw new WarningException($"No se ha configurado ningun subcomponente para el componente de {GeneralConstants.Component.NameComponents[evaluationComponent.ComponentId]}");

                if (evaluationComponent.ComponentId == GeneralConstants.Component.Competencies)
                {
                    conducts = await _unitOfWorkApp.Repository.ConductRepository
                        .Find(c => subcomponents.Select(s => s.Id).Contains(c.SubcomponentId))
                        .Include(i => i.Level)
                        .ToListAsync();
                    levels = await _unitOfWorkApp.Repository.LevelRepository.All().ToListAsync();

                    if (!conducts.Any())
                        throw new WarningException($"No se ha configurado conductas para el componente de {GeneralConstants.Component.NameComponents[evaluationComponent.ComponentId]}");
                }

                evaluationComponent.ComponentsCollaborator = evaluation.EvaluationCollaborators
                    .Select(ec =>
                    {
                        var componentCollaboratorDetails = new List<ComponentCollaboratorDetail>();

                        if (evaluationComponent.ComponentId == GeneralConstants.Component.Competencies)
                            componentCollaboratorDetails = subcomponents
                                    .Select(s =>
                                    {
                                        var conductsByLevel = conducts.Where(c => c.SubcomponentId == s.Id && c.LevelId == ec.LevelId)
                                                                        .ToList();
                                        
                                        return new ComponentCollaboratorDetail
                                        {
                                            SubcomponentName = s.Name,
                                            ComponentCollaboratorConducts = conducts.Where(c => 
                                                            c.SubcomponentId == s.Id && 
                                                            c.LevelId == ec.LevelId
                                                ).Select(c => new ComponentCollaboratorConduct
                                                {
                                                    ConductDescription = c.Description,
                                                    LevelName = levels.First(l => l.Id == ec.LevelId).Name
                                                }).ToList()
                                        };
                                    }).ToList();
                        
                        else
                            componentCollaboratorDetails = subcomponents
                                    .Where(s => s.AreaId == ec.AreaId && s.SubcomponentValues.Select(sv => sv.ChargeId).Contains(ec.ChargeId))
                                    .Select(s =>
                                    {
                                        var subcomponentValue = s.SubcomponentValues.First(sv => sv.SubcomponentId == s.Id && sv.ChargeId == ec.ChargeId);
                                        
                                        return new ComponentCollaboratorDetail
                                        {
                                            SubcomponentName = s.Name,
                                            WeightRelative = subcomponentValue.RelativeWeight,
                                            MinimunPercentage = subcomponentValue.MinimunPercentage,
                                            MaximunPercentage = subcomponentValue.MaximunPercentage,
                                            FormulaName = s.Formula?.Name ?? "",
                                            FormulaQuery = s.Formula?.FormulaQuery ?? "",
                                        };
                                    }).ToList();
                        


                        return new ComponentCollaborator
                        {
                            WeightHierarchy = hierarchiesComponent.First(hc => hc.HierarchyId == ec.HierarchyId).Weight,
                            HierarchyName = hierarchiesComponent.First(hc => hc.HierarchyId == ec.HierarchyId).Hierarchy.Name,
                            StatusId = GeneralConstants.StatusGenerals.Create,
                            ComponentCollaboratorDetails = componentCollaboratorDetails,
                        };
                    
                    }).ToList();
            }

            await _unitOfWorkApp.Repository.EvaluationRepository.AddAsync(evaluation);
            await _unitOfWorkApp.SaveChangesAsync();

            return _mapper.Map<EvaluationDto>(evaluation);
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EvaluationDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PaginationResultDto<EvaluationDto>> GetAllPagingAsync(PrimeTable primeTable)
        {
            throw new NotImplementedException();
        }

        public Task<EvaluationDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }



        #region Helpers Functions

        private async Task<int> CountEvaluationsCurrentPeriod()
        {
            var currentDate = DateTime.UtcNow.GetDatePeru();

            return await _unitOfWorkApp.Repository.EvaluationRepository
                .CountAsync(e => currentDate >= e.StartDate && currentDate <= e.EndDate);
        }
        private async Task<int> CountEvaluationByPeriodConfig()
        {
            var configuration = await _unitOfWorkApp.Repository.LabelDetailRepository
                .Find(e => e.LabelId == GeneralConstants.CountEvaluationAnnualConfigId)
                .FirstOrDefaultAsync();

            if (configuration is null)
                throw new WarningException("No se ha encontrado recurso de configuracion");

            return (int)configuration.RealValue;
        }
        private async Task<List<CollaboratorsToEvaluateDto>> GetCollaboratorApplyToFilterForEvaluation(DateTime currentDate)
        {
            currentDate = currentDate.AddMonths(-3);

            return await _unitOfWorkApp.Repository.CollaboratorRepository
                .Find(c => c.DateAdmission < currentDate)
                .ProjectTo<CollaboratorsToEvaluateDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
        private async Task<List<EvaluationCollaborator>> RegisterCollaboratorsInEvaluation(/*string evaluationId,*/ DateTime currentDate)
        {
            var collaborators = await GetCollaboratorApplyToFilterForEvaluation(currentDate);

            if (!collaborators.Any())
                throw new WarningException("No se ha encontrado colaboradores activos");

            var evaluationCollaborators = collaborators.Select(c => new EvaluationCollaborator
            {
                CollaboratorId = c.CollaboratorId,
                GerencyId = c.GerencyId,
                ChargeId = c.ChargeId,
                AreaId = c.AreaId,
                HierarchyId = c.HierarchyId,
                LevelId = c.LevelId
            }).ToList();

            if (!evaluationCollaborators.Any())
                throw new WarningException("No se ha encontrado ningun colaborador para realizar evaluación");

            return evaluationCollaborators;
        }
        private async Task<(List<HierarchyComponent>, List<Subcomponent>)> GetDataCurrentConfiguration(List<int> componentIds)
        {
            var hierarchyComponents = await _unitOfWorkApp.Repository.HierarchyComponentRepository
                .Find(hc => componentIds.Contains(hc.ComponentId))
                .Include(hc=> hc.Hierarchy)
                .ToListAsync();

            var subcomponents = await _unitOfWorkApp.Repository.SubcomponentRepository
                .Find(s => componentIds.Contains(s.ComponentId))
                .Include(i => i.Formula)
                .Include(i => i.SubcomponentValues)
                .ToListAsync();

            if(!hierarchyComponents.Any())
                throw new WarningException("No se ha encontrado ninguna jerarquia con pesos configurados");
            if (!subcomponents.Any())
                throw new WarningException("No se ha encontrado ningun subcomponente configurado");

            return (hierarchyComponents, subcomponents);
        }

        #endregion

    }
}