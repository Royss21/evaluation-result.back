namespace Application.Main.Services.Report
{
    using Application.Dto.Pagination;
    using Application.Dto.Report;
    using Application.Main.Pagination;
    using Application.Main.Service.Base;
    using Application.Main.Services.Report.Interfaces;
    using Domain.Common.Constants;
    using Domain.Main.EvaResult;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ReportService : BaseService, IReportService
    {
        public ReportService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<IEnumerable<EvaluationCollaboratorFinalResultDto>> GetAllByFinalResultAsync(string globalFilter, Guid? evaluationId)
        {
            if (evaluationId is null)
                return new List<EvaluationCollaboratorFinalResultDto>();


            return  await _unitOfWorkApp.Repository.EvaluationCollaboratorRepository
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
    }
}
