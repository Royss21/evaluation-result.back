namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.EvaResult.Evaluation;

    public interface IEvaluationService
    {
        Task<EvaluationDto> CreateAsync(EvaluationCreateDto request);
    }
}
