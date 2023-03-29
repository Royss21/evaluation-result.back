namespace Application.Main.Services.Report
{
    using Application.Dto.EvaResult.ComponentCollaborator;
    using Application.Dto.Pagination;
    using Application.Dto.Report;
    using Application.Main.Pagination;
    using Application.Main.Service.Base;
    using Application.Main.Services.Report.Interfaces;
    using Domain.Common.Constants;
    using Domain.Main.EvaResult;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Threading.Tasks;

    public class ReportService : BaseService, IReportService
    {
        public ReportService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<IEnumerable<EvaluationCollaboratorFinalResultDto>> GetAllByFinalResultAsync( Guid? evaluationId, string? globalFilter = null)
        {
            if (evaluationId is null)
                return new List<EvaluationCollaboratorFinalResultDto>();

            globalFilter = globalFilter ?? "";

            var resultLabels = await _unitOfWorkApp.Repository.LabelDetailRepository
                    .Find(f => f.LabelId == GeneralConstants.ResultLabelsLabelId)
                    .ToListAsync();

            var evaluationCollaborators = await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository
                    .Find(add =>
                            add.EvaluationId.Equals(evaluationId) &&
                            (
                                add.Collaborator.Name.ToLower().Trim().Contains(globalFilter.ToLower().Trim()) ||
                                add.Collaborator.LastName.ToLower().Trim().Contains(globalFilter.ToLower().Trim()) ||
                                add.Collaborator.MiddleName.ToLower().Trim().Contains(globalFilter.ToLower().Trim()) ||
                                add.Collaborator.DocumentNumber.ToLower().Trim().Contains(globalFilter.ToLower().Trim()) ||
                                add.AreaName.ToLower().Trim().Contains(globalFilter.Trim().ToLower()) ||
                                add.ChargeName.ToLower().Trim().Contains(globalFilter.Trim().ToLower()) ||
                                add.GerencyName.ToLower().Trim().Contains(globalFilter.Trim().ToLower()) ||
                                add.HierarchyName.ToLower().Trim().Contains(globalFilter.Trim().ToLower()) ||
                                add.LevelName.ToLower().Trim().Contains(globalFilter.Trim().ToLower())
                            )
                        )
                    .ProjectTo<EvaluationCollaboratorFinalResultDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();

            evaluationCollaborators.ForEach(f =>
            {
                f.ResultLabel = resultLabels.Find(l => f.FinalResult >= l.MinimunValue && f.FinalResult <= f.FinalResult)?.Name ?? "";
            });

            return evaluationCollaborators;
        }

        public async Task<PaginationResultDto<EvaluationCollaboratorFinalResultDto>> GetAllPagingByFinalResultAsync(EvaluationCollaboratorFinalResultFilterDto filter)
        {

            if (filter.EvaluationId is null)
                return new PaginationResultDto<EvaluationCollaboratorFinalResultDto>
                {
                    Count = 0,
                    Entities = new List<EvaluationCollaboratorFinalResultDto>()
                };

            var resultLabels = await _unitOfWorkApp.Repository.LabelDetailRepository
                    .Find(f => f.LabelId == GeneralConstants.ResultLabelsLabelId)
                    .ToListAsync();

            var parametersDto = PrimeNgToPaginationParametersDto<EvaluationCollaboratorFinalResultDto>.Convert(filter);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<EvaluationCollaborator, EvaluationCollaboratorFinalResultDto>(_mapper);

            if(filter.EvaluationId is not null)
                parametersDomain.FilterWhere = parametersDomain.FilterWhere.AddCondition( a=> a.EvaluationId.Equals(filter.EvaluationId));


            if (!string.IsNullOrWhiteSpace(filter.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add =>
                            add.Collaborator.Name.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.Collaborator.LastName.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.Collaborator.MiddleName.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.Collaborator.DocumentNumber.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.AreaName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                            add.ChargeName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                            add.GerencyName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                            add.HierarchyName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                            add.LevelName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower())
                        );
            }

            var paging = await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository.FindAllPagingAsync(parametersDomain);
            var evaluationCollaborators = await paging.Entities.ProjectTo<EvaluationCollaboratorFinalResultDto>(_mapper.ConfigurationProvider).ToListAsync();

            evaluationCollaborators.ForEach(f =>
            {
                f.ResultLabel = resultLabels.Find(l => f.FinalResult >= l.MinimunValue && f.FinalResult <= f.FinalResult)?.Name ?? "";
            });

            return new PaginationResultDto<EvaluationCollaboratorFinalResultDto>
            {
                Count = paging.Count,
                Entities = evaluationCollaborators
            };
        }

        public async Task<PaginationResultDto<EvaluationCollaboratorarFollowResultDto>> GetAllPagingFollowResultAsync(EvaluationCollaboratorarFollowResultFilterDto filter)
        {
            var currentDate = DateTime.Now.GetDatePeru();
            var evaluationId = await _unitOfWorkApp.Repository.EvaluationRepository
                    .Find(f => currentDate >= f.StartDate && currentDate <= f.EndDate)
                    .Select(s => s.Id)
                    .FirstOrDefaultAsync();
            if (evaluationId.Equals(Guid.Empty))
                return new PaginationResultDto<EvaluationCollaboratorarFollowResultDto>
                {
                    Count = 0,
                    Entities = new List<EvaluationCollaboratorarFollowResultDto>()
                };

            var parametersDto = PrimeNgToPaginationParametersDto<EvaluationCollaboratorarFollowResultDto>.Convert(filter);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<EvaluationCollaborator, EvaluationCollaboratorarFollowResultDto>(_mapper);

            parametersDomain.FilterWhere = parametersDomain.FilterWhere.AddCondition(a => a.EvaluationId.Equals(evaluationId));

            if (!string.IsNullOrWhiteSpace(filter.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add =>
                            add.Collaborator.Name.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.Collaborator.LastName.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.Collaborator.MiddleName.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.Collaborator.DocumentNumber.ToLower().Trim().Contains(filter.GlobalFilter.ToLower().Trim()) ||
                            add.AreaName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                            add.ChargeName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                            add.GerencyName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                            add.HierarchyName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower()) ||
                            add.LevelName.ToLower().Trim().Contains(filter.GlobalFilter.Trim().ToLower())
                        );
            }

            var paging = await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository.FindAllPagingAsync(parametersDomain);
            var evaluationCollaborators = await paging.Entities.ProjectTo<EvaluationCollaboratorarFollowResultDto>(_mapper.ConfigurationProvider).ToListAsync();

            var componentsCollaborators = await _unitOfWorkApp.Repository.ComponentCollaboratorRepository
                    .Find(f => evaluationCollaborators.Select(ec => ec.EvaluationCollaboratorId).Contains(f.EvaluationCollaboratorId))
                    .Select(s => new { s.EvaluationCollaboratorId, s.EvaluationComponent.ComponentId, s.Total })
                    .ToListAsync();

            var evaluationComponentStage = await _unitOfWorkApp.Repository.EvaluationComponentStageRepository
                    .Find(f => f.EvaluationId.Equals(evaluationId))
                    .Select(s => new {
                        s.Id,
                        s.StageId,
                        s.StartDate,
                        s.EndDate,
                        ComponentId = s.EvaluationComponent == null ? 0 : s.EvaluationComponent.ComponentId
                    })
                    .ToListAsync();
            var componentStages = evaluationComponentStage.Where(w => w.ComponentId != 0);
            var componentCollaboratorComments = await _unitOfWorkApp.Repository.ComponentCollaboratorCommentRepository
                    .Find(f => 
                        evaluationCollaborators.Select(ec => ec.EvaluationCollaboratorId).Contains(f.EvaluationCollaboratorId) //&&
                        //componentStages.Select(s => s.Id).Contains(f.EvaluationComponentStageId)
                    )
                    .Select(s => new { 
                        s.Id, 
                        s.EvaluationCollaboratorId,
                        s.EvaluationComponentStage.StageId,
                        ComponentId = s.EvaluationComponentStage.EvaluationComponent == null ? 0 : s.EvaluationComponentStage.EvaluationComponent.ComponentId,
                        s.StatusId })
                    .ToListAsync();

            foreach (var ec in evaluationCollaborators) 
            {
                ec.ResultObjectiveCorporate = componentsCollaborators?.Find(cc => 
                    cc.EvaluationCollaboratorId.Equals(ec.EvaluationCollaboratorId) &&
                    cc.ComponentId == GeneralConstants.Component.CorporateObjectives)?.Total ?? 0.00M;

                ec.StatusObjectiveCorporateId = componentCollaboratorComments?.Find(f => 
                    f.EvaluationCollaboratorId.Equals(ec.EvaluationCollaboratorId) &&
                    f.ComponentId == GeneralConstants.Component.CorporateObjectives)?.StatusId ?? 0;

                ec.ResultObjectiveArea = componentsCollaborators?.Find(cc =>
                    cc.EvaluationCollaboratorId.Equals(ec.EvaluationCollaboratorId) &&
                    cc.ComponentId == GeneralConstants.Component.AreaObjectives)?.Total ?? 0.00M;

                ec.StatusObjectiveAreaId = componentCollaboratorComments?.Find(f =>
                    f.EvaluationCollaboratorId.Equals(ec.EvaluationCollaboratorId) &&
                    f.ComponentId == GeneralConstants.Component.AreaObjectives)?.StatusId ?? 0;

                ec.ResultCompetence = componentsCollaborators?.Find(cc =>
                    cc.EvaluationCollaboratorId.Equals(ec.EvaluationCollaboratorId) &&
                    cc.ComponentId == GeneralConstants.Component.Competencies)?.Total ?? 0.00M;

                ec.StageCurrentId = evaluationComponentStage?.Find(f =>
                    new[] {0, GeneralConstants.Component.Competencies }.Contains(f.ComponentId ) &&
                    (currentDate >= f.StartDate && currentDate <= f.EndDate))?.StageId ?? 0;

                ec.StatusCompetenceId = componentCollaboratorComments?.Find(f =>
                    f.EvaluationCollaboratorId.Equals(ec.EvaluationCollaboratorId) &&
                    f.StageId == ec.StageCurrentId)?.StatusId ?? 0;

            }


            return new PaginationResultDto<EvaluationCollaboratorarFollowResultDto>
            {
                Count = paging.Count,
                Entities = evaluationCollaborators
            };
        }

        public async Task<IEnumerable<EvaluationCollaboratorarFollowResultDto>> GetAllFollowResultAsync(Guid? evaluationId, string? globalFilter = null)
        {
            var currentDate = DateTime.Now.GetDatePeru();
            evaluationId = await _unitOfWorkApp.Repository.EvaluationRepository
                    .Find(f => currentDate >= f.StartDate && currentDate <= f.EndDate)
                    .Select(s => s.Id)
                    .FirstOrDefaultAsync();

            if (evaluationId is null)
                return new List<EvaluationCollaboratorarFollowResultDto>();


            globalFilter = globalFilter ?? "";
            var evaluationCollaborators =  await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository
                    .Find(add =>
                            add.EvaluationId.Equals(evaluationId) &&
                            (
                                add.Collaborator.Name.ToLower().Trim().Contains(globalFilter.ToLower().Trim()) ||
                                add.Collaborator.LastName.ToLower().Trim().Contains(globalFilter.ToLower().Trim()) ||
                                add.Collaborator.MiddleName.ToLower().Trim().Contains(globalFilter.ToLower().Trim()) ||
                                add.Collaborator.DocumentNumber.ToLower().Trim().Contains(globalFilter.ToLower().Trim()) ||
                                add.AreaName.ToLower().Trim().Contains(globalFilter.Trim().ToLower()) ||
                                add.ChargeName.ToLower().Trim().Contains(globalFilter.Trim().ToLower()) ||
                                add.GerencyName.ToLower().Trim().Contains(globalFilter.Trim().ToLower()) ||
                                add.HierarchyName.ToLower().Trim().Contains(globalFilter.Trim().ToLower()) ||
                                add.LevelName.ToLower().Trim().Contains(globalFilter.Trim().ToLower())
                            )
                        )
                    .ProjectTo<EvaluationCollaboratorarFollowResultDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();


            var componentsCollaborators = await _unitOfWorkApp.Repository.ComponentCollaboratorRepository
                    .Find(f => evaluationCollaborators.Select(ec => ec.EvaluationCollaboratorId).Contains(f.EvaluationCollaboratorId))
                    .Select(s => new { s.EvaluationCollaboratorId, s.EvaluationComponent.ComponentId, s.Total })
                    .ToListAsync();

            var evaluationComponentStage = await _unitOfWorkApp.Repository.EvaluationComponentStageRepository
                    .Find(f => f.EvaluationId.Equals(evaluationId))
                    .Select(s => new {
                        s.Id,
                        s.StageId,
                        s.StartDate,
                        s.EndDate,
                        ComponentId = s.EvaluationComponent == null ? 0 : s.EvaluationComponent.ComponentId
                    })
                    .ToListAsync();
            var componentStages = evaluationComponentStage.Where(w => w.ComponentId != 0);
            var componentCollaboratorComments = await _unitOfWorkApp.Repository.ComponentCollaboratorCommentRepository
                    .Find(f =>
                        evaluationCollaborators.Select(ec => ec.EvaluationCollaboratorId).Contains(f.EvaluationCollaboratorId) //&&
                                                                                                                               //componentStages.Select(s => s.Id).Contains(f.EvaluationComponentStageId)
                    )
                    .Select(s => new {
                        s.Id,
                        s.EvaluationCollaboratorId,
                        s.EvaluationComponentStage.StageId,
                        ComponentId = s.EvaluationComponentStage.EvaluationComponent == null ? 0 : s.EvaluationComponentStage.EvaluationComponent.ComponentId,
                        s.StatusId
                    })
                    .ToListAsync();

            foreach (var ec in evaluationCollaborators)
            {
                ec.ResultObjectiveCorporate = componentsCollaborators?.Find(cc =>
                    cc.EvaluationCollaboratorId.Equals(ec.EvaluationCollaboratorId) &&
                    cc.ComponentId == GeneralConstants.Component.CorporateObjectives)?.Total ?? 0.00M;

                ec.StatusObjectiveCorporateId = componentCollaboratorComments?.Find(f =>
                    f.EvaluationCollaboratorId.Equals(ec.EvaluationCollaboratorId) &&
                    f.ComponentId == GeneralConstants.Component.CorporateObjectives)?.StatusId ?? 0;

                ec.ResultObjectiveArea = componentsCollaborators?.Find(cc =>
                    cc.EvaluationCollaboratorId.Equals(ec.EvaluationCollaboratorId) &&
                    cc.ComponentId == GeneralConstants.Component.AreaObjectives)?.Total ?? 0.00M;

                ec.StatusObjectiveAreaId = componentCollaboratorComments?.Find(f =>
                    f.EvaluationCollaboratorId.Equals(ec.EvaluationCollaboratorId) &&
                    f.ComponentId == GeneralConstants.Component.AreaObjectives)?.StatusId ?? 0;

                ec.ResultCompetence = componentsCollaborators?.Find(cc =>
                    cc.EvaluationCollaboratorId.Equals(ec.EvaluationCollaboratorId) &&
                    cc.ComponentId == GeneralConstants.Component.Competencies)?.Total ?? 0.00M;

                ec.StageCurrentId = evaluationComponentStage?.Find(f =>
                    new[] { 0, GeneralConstants.Component.Competencies }.Contains(f.ComponentId) &&
                    (currentDate >= f.StartDate && currentDate <= f.EndDate))?.StageId ?? 0;

                ec.StatusCompetenceId = componentCollaboratorComments?.Find(f =>
                    f.EvaluationCollaboratorId.Equals(ec.EvaluationCollaboratorId) &&
                    f.StageId == ec.StageCurrentId)?.StatusId ?? 0;

            }

            return evaluationCollaborators;
        }
    }
}
