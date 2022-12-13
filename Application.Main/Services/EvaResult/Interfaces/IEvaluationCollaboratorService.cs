namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.EvaResult.EvaluationCollaborator;
    using Application.Dto.Pagination;

    public interface IEvaluationCollaboratorService
    {

        Task<PaginationResultDto<EvaluationCollaboratorPagingDto>> GetPagingAsync(PagingFilterDto primeTable);
        Task<EvaluationCollaboratorDto> CreateAsync(EvaluationCollaboratorCreateDto request);
        Task<bool> DeleteAsync(Guid id);
    }
}
