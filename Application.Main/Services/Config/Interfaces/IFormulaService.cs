namespace Application.Main.Services.Config.Interfaces
{
    using Application.Dto.Config.Formula;
    using Application.Dto.Pagination;

    public interface IFormulaService
    {
        Task<PaginationResultDto<FormulaDto>> GetAllPagingAsync(PagingFilterDto primeTable);
        Task<FormulaDto> GetByIdAsync(Guid id);
        Task<FormulaDto> CreateAsync(FormulaCreateDto request);
        Task<bool> UpdateAsync(FormulaUpdateDto request);
        Task<bool> DeleteAsync(Guid id);
    }
}
