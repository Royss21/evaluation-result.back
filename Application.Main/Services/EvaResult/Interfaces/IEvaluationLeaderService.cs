namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.Config.EvaluationLeader;
    using Application.Dto.EvaResult.EvaluationLeader;
    using Application.Dto.Pagination;

    public interface IEvaluationLeaderService
    {
        Task<bool> ImportBulkAsync(EvaluationLeaderFileDto request);
        Task<PaginationResultDto<EvaluationLeaderDto>> GetAllPagingAsync(EvaluationLeaderFilterDto filter);
    }
}
