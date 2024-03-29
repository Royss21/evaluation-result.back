﻿
namespace Application.Main.Services.EvaResult
{
    using Application.Dto.EvaResult.ComponentCollaborator;
    using Application.Dto.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.Pagination;
    using Application.Main.Service.Base;
    using Application.Main.Services.EvaResult.Interfaces;
    using Domain.Common.Constants;
    using Domain.Main.EvaResult;
    using System.Threading.Tasks;

    public class ComponentCollaboratorService : BaseService, IComponentCollaboratorService
    {
        public ComponentCollaboratorService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<bool> EvaluateAsync(ComponentCollaboratorEvaluateDto request)
        {

            var componentCollaborator = await _unitOfWorkApp.Repository.ComponentCollaboratorRepository
                    .Find(f => f.Id.Equals(request.Id), false)
                    .FirstOrDefaultAsync();

            if (componentCollaborator is null)
                throw new WarningException("El componente a evaluar del colaborador no se ha encontrado");

            var componentCollaboratorDetails = await _unitOfWorkApp.Repository.ComponentCollaboratorDetailRepository
                    .Find(f => request.ComponentCollaboratorDetailsEvaluate.Select(s => s.Id).Contains(f.Id), false)
                    .ToListAsync();

            if (!componentCollaboratorDetails.Any())
                throw new WarningException("Los objetivos/competencias del colaborador no se han encontrado");

            var componentCollaboratorComment = await _unitOfWorkApp.Repository.ComponentCollaboratorCommentRepository
                    .Find(f => f.EvaluationComponentStageId == request.EvaluationComponentStageId, false)
                    .FirstOrDefaultAsync();

            if (componentCollaboratorComment is null)
                throw new WarningException("El recurso para guardar el comentario no se han encontrado");
            
            switch (request.ComponentId)
            {
                case GeneralConstants.Component.CorporateObjectives:

                    var paramatersValue = await _unitOfWorkApp.Repository.ParameterValueRepository
                            .Find( f=> !f.ParameterRange.IsInternalConfiguration)
                            .ToListAsync();
                    var parametersRangeInternal = await _unitOfWorkApp.Repository.ParameterRangeRepository
                            .Find(f => f.IsInternalConfiguration)
                            .Include(i => i.ParametersValue)
                            .FirstOrDefaultAsync();

                    if (parametersRangeInternal is not null && parametersRangeInternal.ParametersValue.Any())
                        paramatersValue.AddRange(parametersRangeInternal.ParametersValue);

                    foreach(var ccd in componentCollaboratorDetails)
                    {
                        var valueResult = request.ComponentCollaboratorDetailsEvaluate
                            .First(f => f.Id == ccd.Id).ValueResult;
                        var formulaQuerySql = ccd.FormulaQuery;
                        ccd.Result = valueResult;

                        foreach (var parameterValue in paramatersValue)
                        {
                            if(formulaQuerySql.Contains(parameterValue.Name))
                                formulaQuerySql = formulaQuerySql.Replace(parameterValue.Name,
                                        parameterValue.ParameterRangeId == parametersRangeInternal.Id
                                            ? ccd.GetType().GetProperty(parameterValue.NameProperty).GetValue(ccd, null)?.ToString() ?? ""
                                            : parameterValue.Value.ToString());
                        }

                        var complianceValue = await CalculateFormulaCompliance(formulaQuerySql);
                        ccd.Compliance = complianceValue;
                        ccd.Points = complianceValue * ccd.WeightRelative;
                    }

                    componentCollaborator.SubTotal = componentCollaboratorDetails.Sum(s => s.Points);
                    componentCollaborator.ExcessSubtotal = componentCollaborator.SubTotal > 100 ? 100 : componentCollaborator.SubTotal;
                    componentCollaborator.Total = componentCollaborator.WeightHierarchy * componentCollaborator.ExcessSubtotal;
                    componentCollaborator.Excess = componentCollaborator.SubTotal > 100 ? componentCollaborator.SubTotal - 100 : 0;

                    componentCollaboratorComment.Comment = request.Comment;

                    break;
                case GeneralConstants.Component.AreaObjectives:

                    var evaluationCollaborator = await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository
                            .Find(f => f.Id.Equals(componentCollaborator.EvaluationCollaboratorId))
                            .FirstAsync();
                    var hasEvaluationLeaderAssigned = await _unitOfWorkApp.Repository.EvaluationLeaderRepository
                            .Find(f => f.AreaName.ToLower().Equals(evaluationCollaborator.AreaName.ToLower()))
                            .AnyAsync();

                    if(!hasEvaluationLeaderAssigned)
                        throw new WarningException("El colaborador no tiene un Lider asignado para evaluar su area");

                    foreach(var ccd in componentCollaboratorDetails)
                    {
                        var valueResult = request.ComponentCollaboratorDetailsEvaluate
                           .First(f => f.Id == ccd.Id).ValueResult;

                        ccd.Result = valueResult;
                        ccd.Compliance = valueResult < ccd.MinimunPercentage ? 0 : valueResult / ccd.MaximunPercentage;
                        ccd.Points = ccd.Compliance * ccd.WeightRelative;
                    }

                    componentCollaborator.SubTotal = componentCollaboratorDetails.Sum(s => s.Points);
                    componentCollaborator.Total = componentCollaborator.WeightHierarchy * componentCollaborator.SubTotal;

                    break;
                case GeneralConstants.Component.Competencies:

                    var componentCollaboratorConducts = await _unitOfWorkApp.Repository.ComponentCollaboratorConductRepository
                            .Find(f => componentCollaboratorDetails.Select(s => s.Id).Contains(f.ComponentCollaboratorDetailId), false)
                            .ToListAsync();

                    if (!componentCollaboratorConducts.Any())
                        throw new WarningException("Las conductas del colaborador no se han encontrado");

                    var leaderCollaborators = await _unitOfWorkApp.Repository.LeaderCollaboratorRepository
                            .Find(f => 
                                f.EvaluationCollaboratorId.Equals(componentCollaborator.EvaluationCollaboratorId) &&
                                new[] { GeneralConstants.Stages.Evaluation, GeneralConstants.Stages.Calibration }.Contains( f.LeaderStage.StageId)
                            )
                            .Include(i => i.LeaderStage)
                            .ToListAsync();

                    if (!leaderCollaborators.Any(lc => lc.LeaderStage.StageId == request.StageId))
                        throw new WarningException("El colaborador no tiene un Lider asignado en esta etapa");


                    switch (request.StageId)
                    {
                        case GeneralConstants.Stages.Evaluation:

                            var countLeaders = leaderCollaborators.Select(lc => lc.LeaderStage.EvaluationLeaderId)
                                    .Distinct()
                                    .Count();

                            componentCollaboratorDetails.ForEach(ccd =>
                            {
                                componentCollaboratorConducts.Where(w => w.ComponentCollaboratorDetailId == ccd.Id).ForEach(ccc =>
                                {
                                    var componentCollaboratorDto = request.ComponentCollaboratorDetailsEvaluate
                                        .First(f =>f.Id == ccd.Id );

                                    ccc.ConductPoints = componentCollaboratorDto.ComponentCollaboratorConductsEvaluate
                                        .First(f => f.Id == ccc.Id).PointValue;

                                    if (countLeaders > 1)
                                        ccc.ConductPointsCalibrated = ccc.ConductPoints;
                                });

                                ccd.Points = componentCollaboratorConducts.Where(w => w.ComponentCollaboratorDetailId == ccd.Id)
                                    .Sum(s => s.ConductPoints);

                                if (countLeaders > 1)
                                    ccd.PointsCalibrated = componentCollaboratorConducts.Where(w => w.ComponentCollaboratorDetailId == ccd.Id)
                                        .Sum(s => s.ConductPointsCalibrated);
                            });

                            componentCollaborator.SubTotal = componentCollaboratorDetails.Sum(s => s.Points);
                            componentCollaborator.Total = 0;
                            componentCollaborator.Total = 0;

                            break;

                        case GeneralConstants.Stages.Calibration:

                            componentCollaboratorDetails.ForEach(ccd =>
                            {
                                componentCollaboratorConducts.ForEach(ccc =>
                                {
                                    var componentCollaboratorDto = request.ComponentCollaboratorDetailsEvaluate
                                        .First(f => f.Id == ccd.Id);

                                    ccc.ConductPointsCalibrated = componentCollaboratorDto.ComponentCollaboratorConductsEvaluate
                                        .First(f => f.Id == ccc.Id).PointValue;
                                });

                                ccd.PointsCalibrated = componentCollaboratorConducts.Sum(s => s.ConductPointsCalibrated);
                            });

                            componentCollaborator.SubTotal = componentCollaboratorDetails.Sum(s => s.PointsCalibrated);
                            componentCollaborator.Total = 0;
                            componentCollaborator.Total = 0;

                            break;

                        default:
                            break;
                    }

                    break;
                default:
                    break;
            }

            componentCollaborator.StatusId = GeneralConstants.StatusIds.Completed;
            componentCollaboratorComment.Comment = request.Comment;
            componentCollaboratorComment.StatusId = GeneralConstants.StatusIds.Completed;

            var componentCollaborators = await _unitOfWorkApp.Repository.ComponentCollaboratorRepository
                    .Find(f => f.EvaluationComponentId == request.EvaluationComponentId)
                    .ProjectTo<ComponentCollaboratorStatusDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            var evaluationComponent = await _unitOfWorkApp.Repository.EvaluationComponentRepository
                    .Find(f => f.Id == request.EvaluationComponentId, false)
                    .FirstAsync();

            componentCollaborators.First(cc => cc.Id == componentCollaborator.Id).StatusId = componentCollaborator.StatusId;
            var countStatusCompleted = componentCollaborators.Where(cc => cc.StatusId == GeneralConstants.StatusIds.Completed).Count();

            if (componentCollaborators.Count == countStatusCompleted)
                evaluationComponent.StatusId = GeneralConstants.StatusIds.Completed;
            else
                evaluationComponent.StatusId = GeneralConstants.StatusIds.Pending;

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<ComponentCollaboratorDto> GetEvaluationDataByIdAsync(Guid id)
        {
            await UpdateStatusAsync(new UpdateStatusDto { 
                Id= id,
                StatusId = GeneralConstants.StatusIds.InProgress
            });

            var componenteCollaborator = await _unitOfWorkApp.Repository.ComponentCollaboratorRepository
                    .Find(f => f.Id.Equals(id))
                    .ProjectTo<ComponentCollaboratorDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();

            if (componenteCollaborator is null)
                throw new WarningException("No se encontró datos para evaluar al colaborador");

            var evaluationComponentStage = await _unitOfWorkApp.Repository.EvaluationComponentStageRepository
                    .Find(f => f.EvaluationComponentId.Equals(componenteCollaborator.EvaluationComponentId))
                    .FirstOrDefaultAsync();

            if (evaluationComponentStage is null)
                throw new WarningException("No se encontró datos para evaluar al colaborador");

            componenteCollaborator.EvaluationComponentStageId = evaluationComponentStage.Id;
            componenteCollaborator.StageId = evaluationComponentStage.StageId;

            return componenteCollaborator;
        }

        public async Task<bool> UpdateStatusAsync(UpdateStatusDto request)
        {
            var componentCollaboratorUpdate = await _unitOfWorkApp.Repository.ComponentCollaboratorRepository
                        .Find(f => f.Id.Equals(request.Id), false)
                        .FirstAsync();

            if (new[] { GeneralConstants.StatusIds.Create,
                GeneralConstants.StatusIds.Pending, 
                GeneralConstants.StatusIds.InProgress 
                }.Contains(componentCollaboratorUpdate.StatusId))
            {
                componentCollaboratorUpdate.StatusId = request.StatusId;
                await _unitOfWorkApp.SaveChangesAsync();
            }

            return true;
        }

        public async Task<PaginationResultDto<ComponentCollaboratorPagingDto>> GetPagingAsync(ComponentCollaboratorFilterDto filter)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<ComponentCollaboratorPagingDto>.Convert(filter);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<ComponentCollaborator, ComponentCollaboratorPagingDto>(_mapper);
            var evaluationComponent = await _unitOfWorkApp.Repository.EvaluationComponentRepository
                    .Find(f => f.EvaluationId.Equals(filter.EvaluationId) && f.ComponentId == filter.ComponentId)
                    .FirstOrDefaultAsync();

            if (evaluationComponent is null)
                throw new WarningException("El componente que desea evaluar no esta creado");

            parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add => add.EvaluationComponent.ComponentId == filter.ComponentId);

            if (!string.IsNullOrWhiteSpace(filter.GlobalFilter))
            {
                filter.GlobalFilter = filter.GlobalFilter ?? "";
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add =>
                            add.EvaluationCollaborator.Collaborator.Name.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.EvaluationCollaborator.Collaborator.LastName.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.EvaluationCollaborator.Collaborator.MiddleName.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.EvaluationCollaborator.Collaborator.DocumentNumber.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.EvaluationCollaborator.AreaName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                            add.EvaluationCollaborator.ChargeName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                            add.EvaluationCollaborator.GerencyName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                            add.HierarchyName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower())
                        );
            }

            var paging = await _unitOfWorkApp.Repository.ComponentCollaboratorRepository.FindAllPagingAsync(parametersDomain);
            var evaluationCollaborators = await paging.Entities.ProjectTo<ComponentCollaboratorPagingDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginationResultDto<ComponentCollaboratorPagingDto>
            {
                Count = paging.Count,
                Entities = evaluationCollaborators
            };
        }

        public async Task<bool> IsDateRangeToEvaluateAsync(Guid evaluationId, int stageId, int? componentId)
        {
            var currentDate = DateTime.UtcNow.GetDatePeru();
            var componentStage = await _unitOfWorkApp.Repository.EvaluationComponentStageRepository
                     .Find(f =>
                         f.EvaluationId.Equals(evaluationId) && f.StageId == stageId ||
                         (componentId != null ? f.EvaluationComponent.ComponentId == componentId : f.EvaluationComponentId == null)
                     ).FirstOrDefaultAsync();

            if (componentStage is null)
                throw new WarningException(Messages.General.ResourceNotFound);

            if (currentDate >= componentStage.StartDate && currentDate <= componentStage.EndDate)
                return true;
            else
                return false;
        }

        #region Helper Functions
        private async Task<decimal> CalculateFormulaCompliance(string formulaQuerySql)
        {
            return (await _unitOfWorkApp.Repository.ComponentCollaboratorRepository
                    .RunSqlQuery<decimal>("[dbo].[uspCalculateFormulaCompliance]", new { formulaQuerySql }))
                    .FirstOrDefault();
        }
        #endregion
    }
}
