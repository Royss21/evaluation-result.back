
namespace Application.Main.Services.EvaResult
{
    using Application.Dto.Config.Subcomponent;
    using Application.Dto.Employee.Collaborator;
    using Application.Dto.EvaResult.Evaluation;
    using Application.Dto.EvaResult.Period;
    using Application.Dto.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.PrimeNg;
    using Application.Main.Service.Base;
    using Application.Main.Services.EvaResult.Interfaces;
    using Domain.Common.Constants;
    using Domain.Main.Config;
    using Domain.Main.EvaResult;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EvaluationService : BaseService, IEvaluationService
    {
        public EvaluationService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<EvaluationDto> CreateAsync(EvaluationCreateDto request)
        {
            if (!request.EvaluationComponents.Any())
                throw new WarningException("No hay ningun componente seleccionado para la evaluacion.");

            if (request.EvaluationComponents.Any(ec => ec.ComponentId == GeneralConstants.Component.Competencies) && 
                !request.EvaluationComponentStages.Where(w=> w.ComponentId == GeneralConstants.Component.Competencies).Any()
               )
                throw new WarningException("No ha seleccionado las etapas del componente de COMPETENCIAS");

            if (!request.IsEvaluationTest)
            {
                var countEvaluations = await CountEvaluationsCurrentPeriod();
                var countEvaluationsConfig = await CountEvaluationByPeriodConfig();

                if (countEvaluations == countEvaluationsConfig)
                    throw new WarningException($"Llegó al limite de {countEvaluationsConfig} evaluaciones por periodo");
            }

            var evaluation = _mapper.Map<Evaluation>(request);
            var currentDate = DateTime.UtcNow.GetDatePeru();
            var evaluationComponents = _mapper.Map<List<EvaluationComponent>>(request.EvaluationComponents);
            var components = await _unitOfWorkApp.Repository.ComponentRepository.All().ToListAsync();
            var dataConfigurations = await GetDataCurrentConfiguration(evaluationComponents.Select(ce => ce.ComponentId).ToList());
            
            evaluation.EvaluationComponents = evaluationComponents;
            evaluation.EvaluationCollaborators = await RegisterCollaboratorsInEvaluation(currentDate);
            evaluation.EvaluationComponentStages = _mapper.Map<List<EvaluationComponentStage>>(request.EvaluationComponentStages.Where(w => w.ComponentId is null));
            evaluation.StatusId = request.IsEvaluationTest
                                        ? GeneralConstants.StatusIds.Test
                                        : currentDate.RangeDateBetween(evaluation.StartDate, evaluation.EndDate)
                                            ? GeneralConstants.StatusIds.InProgress
                                            : GeneralConstants.StatusIds.Create;
            evaluation.EvaluationCollaborators
                .ForEach(ec => 
                    ec.ComponentCollaboratorComments = evaluation.EvaluationComponentStages
                        .Select(ecs => new ComponentCollaboratorComment { 
                            EvaluationComponentStage = ecs,
                            StatusId = GeneralConstants.StatusIds.Create
                        })
                .ToList());

            foreach (var evaluationComponent in evaluation.EvaluationComponents)
            {
                var hierarchiesComponent = dataConfigurations.Item1;
                var subcomponents = dataConfigurations.Item2;
                var conducts = new List<Conduct>();

                hierarchiesComponent = hierarchiesComponent.Where(s => s.ComponentId == evaluationComponent.ComponentId).ToList();
                subcomponents = subcomponents.Where(s => s.ComponentId == evaluationComponent.ComponentId).ToList();

                if (!hierarchiesComponent.Any())
                    throw new WarningException($"No se ha configurado el peso de las jerarquias para el componente de {GeneralConstants.Component.ComponentsName[evaluationComponent.ComponentId]}");

                if (!subcomponents.Any())
                    throw new WarningException($"No se ha configurado ningun subcomponente para el componente de {GeneralConstants.Component.ComponentsName[evaluationComponent.ComponentId]}");

                if (evaluationComponent.ComponentId == GeneralConstants.Component.Competencies)
                {
                    conducts = await _unitOfWorkApp.Repository.ConductRepository
                        .Find(c => subcomponents.Select(s => s.Id).Contains(c.SubcomponentId))
                        .Include(i => i.Level)
                        .ToListAsync();
                    if (!conducts.Any())
                        throw new WarningException($"No se ha configurado conductas para el componente de {GeneralConstants.Component.ComponentsName[evaluationComponent.ComponentId]}");

                    evaluationComponent.EvaluationComponentStages = _mapper.Map<List<EvaluationComponentStage>>(request.EvaluationComponentStages
                                                                                                                        .Where(w => w.ComponentId is not null));
                }
                else
                {
                    var evaluationComponentDto = request.EvaluationComponents.First(ec => ec.ComponentId == evaluationComponent.ComponentId);
                    evaluationComponent.EvaluationComponentStages = new List<EvaluationComponentStage> { 
                        new EvaluationComponentStage { 
                            StageId = GeneralConstants.Stages.Evaluation,
                            StartDate = evaluationComponentDto.StartDate,
                            EndDate = evaluationComponentDto.EndDate
                        } 
                    };
                }

                foreach (var ec in evaluation.EvaluationCollaborators)
                {
                    evaluationComponent.EvaluationComponentStages
                        .ForEach(ecs => ec.ComponentCollaboratorComments.Add(new ComponentCollaboratorComment { 
                            EvaluationComponentStage = ecs,
                            StatusId = GeneralConstants.StatusIds.Create
                        }));

                    var hierarchyComponent = hierarchiesComponent.First(hc => hc.Hierarchy.Name.ToLower().Equals(ec.HierarchyName.ToLower()));
                    var componentCollaboratorDetails = new List<ComponentCollaboratorDetail>();

                    if (evaluationComponent.ComponentId == GeneralConstants.Component.Competencies)
                    {
                        var conductsOfCollaborator = conducts.Where(c => c.Level.Name.ToLower().Equals(ec.LevelName.ToLower()));
                        var subcomponentsOfCollaborator = subcomponents.Where(s =>
                            conductsOfCollaborator.Select(coc => coc.SubcomponentId).Contains(s.Id)
                        ).ToList();

                        componentCollaboratorDetails = subcomponentsOfCollaborator
                                .Select(s =>
                                {
                                    return new ComponentCollaboratorDetail
                                    {
                                        FormulaName = "",
                                        FormulaQuery = "",
                                        SubcomponentName = s.Name,
                                        ComponentCollaboratorConducts = conductsOfCollaborator.Where(c => c.SubcomponentId.Equals(s.Id))
                                            .Select(c => new ComponentCollaboratorConduct
                                            {
                                                ConductDescription = c.Description,
                                                LevelName = c.Level.Name
                                            }).ToList()
                                    };
                                }).ToList();
                    }
                    else
                        componentCollaboratorDetails = subcomponents
                                .Where(s =>
                                        s.AreaName.ToLower().Equals(ec.AreaName.ToLower()) &&
                                        s.SubcomponentValues.Select(sv => sv.ChargeName.ToLower()).Contains(ec.ChargeName.ToLower())
                                )
                                .Select(s =>
                                {
                                    var subcomponentValue = s.SubcomponentValues.First(sv => sv.SubcomponentId.Equals(s.Id) &&
                                                                                    sv.ChargeName.ToLower().Equals(ec.ChargeName.ToLower()));

                                    return new ComponentCollaboratorDetail
                                    {
                                        SubcomponentName = s.Name,
                                        WeightRelative = subcomponentValue.RelativeWeight,
                                        MinimunPercentage = subcomponentValue.MinimunPercentage,
                                        MaximunPercentage = subcomponentValue.MaximunPercentage,
                                        FormulaName = s.FormulaName ?? "",
                                        FormulaQuery = s.FormulaQuery ?? "",
                                    };
                                }).ToList();

                    evaluationComponent.ComponentsCollaborator.Add(new ComponentCollaborator
                    {
                        EvaluationCollaborator = ec,
                        StatusId = GeneralConstants.StatusIds.Create,
                        WeightHierarchy = hierarchyComponent.Weight,
                        HierarchyName = hierarchyComponent.Hierarchy.Name,
                        ComponentName = components.First(c => c.Id == evaluationComponent.ComponentId).Name ,
                        ComponentCollaboratorDetails = componentCollaboratorDetails
                    });
                }

                evaluationComponent.EvaluationComponentStages.ForEach(ecs => ecs.Evaluation = evaluation );
                evaluationComponent.StatusId = GeneralConstants.StatusIds.Create;
            }

            await _unitOfWorkApp.Repository.EvaluationRepository.AddAsync(evaluation);
            await _unitOfWorkApp.SaveChangesAsync();

            return _mapper.Map<EvaluationDto>(evaluation);
        }
        public async Task<EvaluationCurrentDetailDto> GetEvaluationDetailAsync(Guid evaluationId)
        {

            var evaluation = await _unitOfWorkApp.Repository.EvaluationRepository
                    .Find(p => p.Id.Equals(evaluationId))
                    .ProjectTo<EvaluationCurrentDetailDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

            if (evaluation is null)
                throw new WarningException("No se ha encontrado datos de la evaluación");

            return evaluation;
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
                .Find(e => e.LabelId == GeneralConstants.CountEvaluationAnnualLabelId)
                .FirstOrDefaultAsync();

            if (configuration is null)
                throw new WarningException("No se ha encontrado recurso de configuracion de Cantidad Evaluaciones por Periodo");

            return (int)configuration.RealValue;
        }
        private async Task<List<CollaboratorsToEvaluateDto>> GetCollaboratorApplyToFilterForEvaluation(DateTime currentDate)
        {
            currentDate = currentDate.AddMonths(GeneralConstants.MonthsToSubtract);

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
                GerencyName = c.GerencyName,
                ChargeName = c.ChargeName,
                AreaName = c.AreaName,
                HierarchyName = c.HierarchyName,
                LevelName = c.LevelName
            }).ToList();

            if (!evaluationCollaborators.Any())
                throw new WarningException("No se ha encontrado ningun colaborador para realizar evaluación");

            return evaluationCollaborators;
        }
        private async Task<(List<HierarchyComponent>, List<SubcomponentDataConfigurationDto>)> GetDataCurrentConfiguration(List<int> componentIds)
        {
            var hierarchyComponents = await _unitOfWorkApp.Repository.HierarchyComponentRepository
                .Find(hc => componentIds.Contains(hc.ComponentId))
                .Include(hc=> hc.Hierarchy)
                .ToListAsync();

            var subcomponents = await _unitOfWorkApp.Repository.SubcomponentRepository
                .Find(s => componentIds.Contains(s.ComponentId))
                .ProjectTo<SubcomponentDataConfigurationDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (!hierarchyComponents.Any())
                throw new WarningException("No se ha encontrado ninguna jerarquia con pesos configurados");
            if (!subcomponents.Any())
                throw new WarningException("No se ha encontrado ningun subcomponente configurado");

            return (hierarchyComponents, subcomponents);
        }

        #endregion

    }
}
