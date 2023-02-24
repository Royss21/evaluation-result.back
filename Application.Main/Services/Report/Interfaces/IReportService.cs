
namespace Application.Main.Services.Report.Interfaces
{
    using Application.Dto.Pagination;
    using Application.Dto.Report;

    public interface IReportService
    {
        Task<PaginationResultDto<EvaluationCollaboratorFinalResultDto>> GetAllPagingByFinalResultAsync(EvaluationCollaboratorFinalResultFilterDto pagingFilter);
        Task<IEnumerable<EvaluationCollaboratorFinalResultDto>> GetAllByFinalResultAsync(string globalFilter, Guid? evaluationId);
    }
}
