namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.Config.EvaluationLeader;
    using Application.Dto.EvaResult.EvaluationLeader;
    using Application.Dto.Pagination;

    public interface IEvaluationLeaderService
    {
        Task<bool> ImportBulkAsync(EvaluationLeaderFileDto request);
        Task<PaginationResultDto<EvaluationLeaderDto>> GetAllPagingAsync(EvaluationLeaderFilterDto filter);
        Task<(IEnumerable<LeaderCollaboratorsDto>, int)> GetAllCollaboratorByLeaderAsync(int evaluationLeaderId, LeaderCollaboratorsFilterDto filter);
        Task<bool> ExistsPreviousImportAsync(int componentId);
    }
}
