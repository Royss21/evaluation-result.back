namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.EvaResult.EvaluationCollaborator;
    using Application.Dto.Pagination;
    using Application.Main.PrimeNg;

    public interface IEvaluationCollaboratorService
    {
        Task<IEnumerable<EvaluationCollaboratorDto>> GetAllAsync();
        Task<PaginationResultDto<EvaluationCollaboratorPagingDto>> GetAllPagingAsync(PagingFilterDto primeTable);
        Task<EvaluationCollaboratorDto> GetByIdAsync(Guid id);
        Task<EvaluationCollaboratorDto> CreateAsync(EvaluationCollaboratorCreateDto request);
        Task<bool> DeleteAsync(Guid id);

    }
}
