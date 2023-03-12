namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.Config.EvaluationLeader;
    using Application.Dto.EvaResult.EvaluationLeader;
    using Application.Dto.Pagination;
    using Microsoft.AspNetCore.Mvc;

    public interface IEvaluationLeaderService
    {
        Task<bool> ImportLeadersAsync(EvaluationLeaderFileDto request, Controller controller);
        Task<PaginationResultDto<EvaluationLeaderDto>> GetAllPagingAsync(EvaluationLeaderFilterDto filter);
        Task<(IEnumerable<LeaderCollaboratorsDto>, int)> GetAllCollaboratorByLeaderAsync(int evaluationLeaderId, LeaderCollaboratorsFilterDto filter);
        Task<bool> ExistsPreviousImportAsync(int componentId);
        Task<LeaderEvaluateComponentDto> GetComponentsToEvaluateAsync(Guid evaluationCollaboratorId);
        Task<CollaboratorLeaderEvaluateDto> GetComponentAndStageLeaderAsync(Guid evaluationCollaboratorId);
    }
}
