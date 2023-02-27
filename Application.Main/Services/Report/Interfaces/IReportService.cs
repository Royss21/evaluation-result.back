
namespace Application.Main.Services.Report.Interfaces
{
    using Application.Dto.Pagination;
    using Application.Dto.Report;

    public interface IReportService
    {
        Task<PaginationResultDto<EvaluationCollaboratorFinalResultDto>> GetAllPagingByFinalResultAsync(EvaluationCollaboratorFinalResultFilterDto pagingFilter);
        Task<IEnumerable<EvaluationCollaboratorFinalResultDto>> GetAllByFinalResultAsync(Guid? evaluationId, string? globalFilter = null);
        Task<PaginationResultDto<EvaluationCollaboratorarFollowResultDto>> GetAllPagingFollowResultAsync(EvaluationCollaboratorarFollowResultFilterDto filter);
        Task<IEnumerable<EvaluationCollaboratorarFollowResultDto>> GetAllFollowResultAsync(Guid? evaluationId, string? globalFilter = null);
    }
}
