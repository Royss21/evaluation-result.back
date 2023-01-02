namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.EvaResult.ComponentCollaborator;
    using Application.Dto.EvaResult.Evaluation;
    using Application.Dto.Pagination;
    using Domain.Main.EvaResult;

    public interface IComponentCollaboratorService
    {
        Task<bool> EvaluateAsync(ComponentCollaboratorEvaluateDto request);
        Task<ComponentCollaboratorDto> GetEvaluationDataByIdAsync(Guid id);
        Task<PaginationResultDto<ComponentCollaboratorPagingDto>> GetPagingAsync(ComponentCollaboratorFilterDto filter);
        Task<bool> UpdateStatusCommentAsync(UpdateStatusDto request, bool isUpdateComponent = true);
        Task<bool> IsDateRangeToEvaluateAsync(Guid evaluationId, int stageId, int? componentId);
        Task<EvaluationComponentStage> GetEvaluationComponentStageAsync(int? componentId = null, int? evaluationComponentId = null, Guid? evaluationId = null);

    }
}
