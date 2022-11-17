
namespace Application.Main.Services.EvaResult
{
    using Application.Dto.EvaResult.ComponentCollaborator;
    using Application.Main.Exceptions;
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
            var isStatusCompleted = false;
            var componentCollaborator = await _unitOfWorkApp.Repository.ComponentCollaboratorRepository
                    .Find(f => f.Id.Equals(request.ComponentCollaboratorId), false)
                    .FirstOrDefaultAsync();
            //var componentCollaboratorConducts = new List<ComponentCollaboratorConduct>();

            if (componentCollaborator is null)
                throw new WarningException("El componente a evaluar del colaborador no se ha encontrado");

            var componentCollaboratorDetails = await _unitOfWorkApp.Repository.ComponentCollaboratorDetailRepository
                    .Find(f => request.ComponentCollaboratorDetailsEvaluateDto.Select(s => s.ComponentCollaboratorDetailId).Contains(f.Id), false)
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
                            .All()
                            .ToListAsync();
                    var parametersRangeInternal = await _unitOfWorkApp.Repository.ParameterRangeRepository
                            .Find(f => f.IsInternalConfiguration)
                            .Include(i => i.ParametersValue)
                            .FirstOrDefaultAsync();

                    if (parametersRangeInternal is not null && parametersRangeInternal.ParametersValue.Any())
                        paramatersValue.AddRange(parametersRangeInternal.ParametersValue);

                    componentCollaboratorDetails.ForEach(async ccd =>
                    {
                        var valueResult = request.ComponentCollaboratorDetailsEvaluateDto
                            .First(f=> f.ComponentCollaboratorDetailId == ccd.Id).ValueResult;
                        var formulaQuerySql = ccd.FormulaQuery;
                        ccd.Result = valueResult;
                        
                        foreach(var parameterValue in paramatersValue)
                        {
                            formulaQuerySql = formulaQuerySql.Replace(parameterValue.Name,
                                    parameterValue.ParameterRangeId == parametersRangeInternal.Id
                                        ? ccd.GetType().GetProperty(parameterValue.NameProperty).GetValue(ccd, null)?.ToString() ?? ""
                                        : parameterValue.Value.ToString());
                        }


                        
                        var complianceValue = await CalculateFormulaCompliance(formulaQuerySql);
                        ccd.Compliance = complianceValue;
                        ccd.Points = complianceValue * ccd.WeightRelative;
                    });

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

                    componentCollaboratorDetails.ForEach(async ccd =>
                    {
                        var valueResult = request.ComponentCollaboratorDetailsEvaluateDto
                            .First(f => f.ComponentCollaboratorDetailId == ccd.Id).ValueResult;

                        ccd.Result = valueResult;
                        ccd.Compliance = valueResult < ccd.MinimunPercentage ? 0 : valueResult / ccd.MaximunPercentage;
                        ccd.Points = ccd.Compliance * ccd.WeightRelative;
                    });

                    componentCollaborator.SubTotal = componentCollaboratorDetails.Sum(s => s.Points);
                    componentCollaborator.Total = componentCollaborator.WeightHierarchy * componentCollaborator.SubTotal;

                    break;
                case GeneralConstants.Component.Competencies:

                    var componentCollaboratorConducts = await _unitOfWorkApp.Repository.ComponentCollaboratorConductRepository
                            .Find(f => componentCollaboratorDetails.Select(s => s.Id).Contains(f.ComponentCollaboratorDetailId))
                            .ToListAsync();

                    if (!componentCollaboratorConducts.Any())
                        throw new WarningException("Las conductas del colaborador no se han encontrado");

                    var leaderCollaborators = await _unitOfWorkApp.Repository.LeaderCollaboratorRepository
                            .Find(f => 
                                f.EvaluationCollaboratorId.Equals(componentCollaborator.Id) &&
                                new[] { GeneralConstants.Stages.Evaluation, GeneralConstants.Stages.Calibration }.Contains( f.LeaderStage.StageId)
                            )
                            .Include(i => i.LeaderStage)
                            .ToListAsync();

                    if (!leaderCollaborators.Any(lc => lc.LeaderStage.StageId == request.StageId))
                        throw new WarningException("El colaborador no tiene un Lider asignado en esta estapa");


                    switch (request.StageId)
                    {
                        case GeneralConstants.Stages.Evaluation:

                            var countLeaders = leaderCollaborators.Select(lc => lc.LeaderStage.EvaluationLeaderId)
                                    .Distinct()
                                    .Count();

                            componentCollaboratorDetails.ForEach(ccd =>
                            {
                                componentCollaboratorConducts.ForEach(ccc =>
                                {
                                    var componentCollaboratorDto = request.ComponentCollaboratorDetailsEvaluateDto
                                        .First(f =>f.ComponentCollaboratorDetailId == ccd.Id );

                                    ccc.ConductPoints = componentCollaboratorDto.ComponentCollaboratorConductsEvaluateDto
                                        .First(f => f.ComponentCollaboratorConductId == ccc.Id).PointValue;

                                    if (countLeaders > 1)
                                        ccc.ConductPointsCalibrated = ccc.ConductPoints;
                                });

                                ccd.Points = componentCollaboratorConducts.Sum(s => s.ConductPoints);

                                if (countLeaders > 1)
                                    ccd.PointsCalibrated = componentCollaboratorConducts.Sum(s => s.ConductPointsCalibrated);
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
                                    var componentCollaboratorDto = request.ComponentCollaboratorDetailsEvaluateDto
                                        .First(f => f.ComponentCollaboratorDetailId == ccd.Id);

                                    ccc.ConductPointsCalibrated = componentCollaboratorDto.ComponentCollaboratorConductsEvaluateDto
                                        .First(f => f.ComponentCollaboratorConductId == ccc.Id).PointValue;
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

            componentCollaborator.StatusId = GeneralConstants.Status.Completed;
            componentCollaboratorComment.Comment = request.Comment;
            componentCollaboratorComment.StatusId = GeneralConstants.Status.Completed;

            var componentCollaborators = await _unitOfWorkApp.Repository.ComponentCollaboratorRepository
                    .Find(f => f.EvaluationComponentId == request.EvaluationComponentId)
                    .ProjectTo<ComponentCollaboratorStatusDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            var evaluationComponent = await _unitOfWorkApp.Repository.EvaluationComponentRepository
                    .Find(f => f.Id == request.EvaluationComponentId, false)
                    .FirstAsync();

            componentCollaborators.First(cc => cc.Id == componentCollaborator.Id).StatusId = componentCollaborator.StatusId;
            var countStatusCompleted = componentCollaborators.Where(cc => cc.StatusId == GeneralConstants.Status.Completed).Count();

            if (componentCollaborators.Count == countStatusCompleted)
                evaluationComponent.StatusId = GeneralConstants.Status.Completed;
            else
                evaluationComponent.StatusId = GeneralConstants.Status.Pending;

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
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
