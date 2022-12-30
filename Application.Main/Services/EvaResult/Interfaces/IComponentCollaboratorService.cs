namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.EvaResult.ComponentCollaborator;
    using Application.Dto.Pagination;

    public interface IComponentCollaboratorService
    {
        Task<bool> EvaluateAsync(ComponentCollaboratorEvaluateDto request);
        Task<ComponentCollaboratorDto> GetEvaluationDataByIdAsync(Guid id);
        Task<PaginationResultDto<ComponentCollaboratorPagingDto>> GetPagingAsync(ComponentCollaboratorFilterDto filter);
        Task<bool> UpdateStatusCommentAsync(UpdateStatusDto request);
        Task<bool> IsDateRangeToEvaluateAsync(Guid evaluationId, int stageId, int? componentId);
    }
}
