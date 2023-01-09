namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.EvaResult.Evaluation;
    using Application.Dto.EvaResult.Period;

    public interface IEvaluationService
    {
        Task<EvaluationDto> CreateAsync(EvaluationCreateDto request);
        Task<EvaluationCurrentDetailDto> GetEvaluationDetailAsync(Guid evaluationId);
        Task<IEnumerable<EvaluationCurrentDetailDto>> GetAllAsync();
    }
}
