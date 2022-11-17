namespace Application.Main.Services.Employee.Interfaces
{
    using Application.Dto.Employee.Area;
    using Application.Dto.Pagination;
    using Application.Main.PrimeNg;

    public interface IAreaService
    {
        Task<IEnumerable<AreaDto>> GetAllAsync();
        Task<PaginationResultDto<AreaDto>> GetAllPagingAsync(PagingFilterDto primeTable);
        Task<AreaDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(AreaCreateDto request);
        Task<bool> DeleteAsync(int id);
    }
}
