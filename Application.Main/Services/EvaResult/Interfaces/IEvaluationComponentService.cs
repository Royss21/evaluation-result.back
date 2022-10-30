namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.EvaResult.EvaluationComponent;

    public interface IEvaluationComponentService
    {
        Task<EvaluationComponentDto> CreateAsync(EvaluationComponentCreateDto request);
    }
}
