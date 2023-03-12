namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.EvaResult.Evaluation;
    using Application.Dto.EvaResult.EvaluationCollaborator;
    using Application.Dto.Pagination;
    using Microsoft.AspNetCore.Mvc;

    public interface IEvaluationCollaboratorService
    {

        Task<PaginationResultDto<EvaluationCollaboratorPagingDto>> GetPagingAsync(PagingFilterDto primeTable);
        Task<EvaluationCollaboratorDto> CreateAsync(EvaluationCollaboratorCreateDto request);
        Task<bool> DeleteAsync(Guid id);
        Task<EvaluationCollaboratorResultDto> GetEvaluationResultByIdAsync(Guid evaluationId, Guid evaluationCollaboratorId);
        Task<bool> SaveCommentEvaluationStageAsync(CommentEvaluationDto request, Controller controller);
        Task<PaginationResultDto<EvaluationCollaboratorReviewPagingDto>> GetPagingCollaboratorReviewStageEvaluationAsync(EvaluationCollaboratorReviewFilterDto filter);
    }
}
