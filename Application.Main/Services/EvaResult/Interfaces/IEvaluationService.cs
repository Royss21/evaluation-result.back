namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.EvaResult.Evaluation;

    public interface IEvaluationService
    {
        Task<EvaluationDto> CreateAsync(EvaluationCreateDto request);
        Task<EvaluationInProgressDto> GetEvaluationInProgressAsync();
        Task<EvaluationCurrentDetailDto> GetEvaluationDetailAsync(Guid evaluationId);
    }
}
