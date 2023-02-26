namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.EvaResult.Evaluation;
    using Application.Dto.EvaResult.Period;

    public interface IEvaluationService
    {
        Task<bool> CreateAsync(EvaluationCreateDto request);
        Task<EvaluationDetailDto> GetEvaluationDetailAsync(Guid evaluationId);
        Task<IEnumerable<EvaluationDetailDto>> GetAllEvaluationDetailAsync();
        Task<EvaluationDto> GetEnabledComponentsAsync(Guid id);
        Task<IEnumerable<EvaluationListDto>> GetAllEvaluationFinishedAsync();
        //Task<IEnumerable<EvaluationDDDto>> GetAllAsync();
    }
}
