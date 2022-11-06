
namespace Application.Main.Services.EvaResult
{
    using Application.Dto.EvaResult.EvaluationCollaborator;
    using Application.Dto.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.PrimeNg;
    using Application.Main.Service.Base;
    using Application.Main.Services.EvaResult.Interfaces;
    using Domain.Common.Constants;
    using Domain.Main.Config;
    using Domain.Main.EvaResult;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EvaluationCollaboratorService : BaseService, IEvaluationCollaboratorService
    {
        public EvaluationCollaboratorService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<EvaluationCollaboratorDto> CreateAsync(EvaluationCollaboratorCreateDto request)
        {
            var evaluationCollaborator = _mapper.Map<EvaluationCollaborator>(request);
            var evaluationComponents = await _unitOfWorkApp.Repository.EvaluationComponentRepository
                    .Find(f => f.EvaluationId.Equals(request.EvaluationId))
                    .Include(i => i.Component)
                    .ToListAsync();
            var componentIds = evaluationComponents.Select(ec => ec.ComponentId).ToList();
            var hierarchyComponentsOfCollaborator = await _unitOfWorkApp.Repository.HierarchyComponentRepository
                    .Find(h => h.HierarchyId == request.HierarchyId)
                    .Include(hc => hc.Hierarchy)
                    .ToListAsync();
            var subcomponentsOfCollaborator = await _unitOfWorkApp.Repository.SubcomponentRepository
                   .Find(s => 
                        componentIds.Contains(s.ComponentId) && 
                        (s.AreaId == request.AreaId || s.AreaId == null)
                    )
                   .Include("Formula")
                   .Include("SubcomponentValues")
                   .ToListAsync();

            foreach (var evaluationComponent in evaluationComponents)
            {
                var conducts = new List<Conduct>();
                var hierarchiesComponents = hierarchyComponentsOfCollaborator.Where(s => s.ComponentId == evaluationComponent.ComponentId).ToList();
                var subcomponents = subcomponentsOfCollaborator.Where(s => s.ComponentId == evaluationComponent.ComponentId).ToList();
                var hierarchyComponent = hierarchiesComponents.First(hc => hc.HierarchyId == request.HierarchyId);

                if (!hierarchiesComponents.Any())
                    throw new WarningException($"No se ha configurado el peso de las jerarquia para el componente de {GeneralConstants.Component.NameComponents[evaluationComponent.ComponentId]}");

                if (!subcomponents.Any())
                    throw new WarningException($"No se ha configurado ningun subcomponente para el componente de {GeneralConstants.Component.NameComponents[evaluationComponent.ComponentId]}");

                if (evaluationComponent.ComponentId == GeneralConstants.Component.Competencies)
                {
                    conducts = await _unitOfWorkApp.Repository.ConductRepository
                        .Find(c => subcomponents.Select(s => s.Id).Contains(c.SubcomponentId) && c.LevelId == request.LevelId)
                        .Include(i => i.Level)
                        .ToListAsync();

                    if (!conducts.Any())
                        throw new WarningException($"No se ha configurado conductas para el componente de {GeneralConstants.Component.NameComponents[evaluationComponent.ComponentId]}");
                }

                var componentCollaboratorDetails = new List<ComponentCollaboratorDetail>();

                if (evaluationComponent.ComponentId == GeneralConstants.Component.Competencies)
                    componentCollaboratorDetails = subcomponents
                            .Select(s =>
                            {
                                return new ComponentCollaboratorDetail
                                {
                                    FormulaName = "",
                                    FormulaQuery = "",
                                    SubcomponentName = s.Name,
                                    ComponentCollaboratorConducts = conducts.Where(c => c.SubcomponentId == s.Id)
                                                            .Select(c => new ComponentCollaboratorConduct
                                                            {
                                                                ConductDescription = c.Description,
                                                                LevelName = c.Level.Name
                                                            }).ToList()
                                };
                            }).ToList();
                else
                    componentCollaboratorDetails = subcomponents
                            .Where(s => s.SubcomponentValues.Select(sv => sv.ChargeId).Contains(request.ChargeId))
                            .Select(s =>
                            {
                                var subcomponentValue = s.SubcomponentValues.First(sv => sv.SubcomponentId == s.Id && sv.ChargeId == request.ChargeId);

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

                evaluationCollaborator.ComponentsCollaborator.Add(new ComponentCollaborator
                {
                    StatusId = GeneralConstants.StatusGenerals.Create,
                    WeightHierarchy = hierarchyComponent.Weight,
                    HierarchyName = hierarchyComponent.Hierarchy.Name,
                    ComponentName = evaluationComponent.Component.Name,
                    ComponentCollaboratorDetails = componentCollaboratorDetails
                });
            }

            await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository.AddAsync(evaluationCollaborator);
            await _unitOfWorkApp.SaveChangesAsync();

            var leaderCollaborators = await _unitOfWorkApp.Repository.LeaderCollaboratorRepository
                    .Find(lc => lc.EvaluationCollaboratorId.Equals(evaluationCollaborator.Id))
                    .ToListAsync();

            var evaluationLeaders = await _unitOfWorkApp.Repository.EvaluationLeaderRepository
                    .Find(lc => lc.EvaluationCollaboratorId.Equals(evaluationCollaborator.Id))
                    .ToListAsync();

            //if(leaderCollaborators.Any())

            return _mapper.Map<EvaluationCollaboratorDto>(evaluationCollaborator);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EvaluationCollaboratorDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PaginationResultDto<EvaluationCollaboratorPagingDto>> GetAllPagingAsync(PrimeTable primeTable)
        {
            throw new NotImplementedException();
        }

        public Task<EvaluationCollaboratorDto> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
