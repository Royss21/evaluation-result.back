namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.EvaResult.Evaluation;

    public interface IEvaluationService
    {
        Task<EvaluationResDto> CreateAsync(EvaluationCreateDto request);
        Task<EvaluationDetailDto> GetEvaluationDetailAsync(Guid evaluationId);
        Task<IEnumerable<EvaluationDetailDto>> GetAllEvaluationDetailAsync();
        Task<EvaluationDto> GetEnabledComponentsAsync(Guid id);
        Task<IEnumerable<EvaluationListDto>> GetAllEvaluationFinishedAsync();
        Task<bool> DeleteAsync(Guid id);
        //Task<IEnumerable<EvaluationDDDto>> GetAllAsync();
    }
}
