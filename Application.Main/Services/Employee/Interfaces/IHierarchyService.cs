namespace Application.Main.Services.Employee.Interfaces
{
    using Application.Dto.Employee.Hierarchy;
    using Application.Dto.Pagination;

    public interface IHierarchyService
    {
        Task<IEnumerable<HierarchyDto>> GetAllAsync();
        Task<bool> UpdateAsync(HierarchyUpdateDto request);
        Task<HierarchyDto> CreateAsync(HierarchyCreateDto request);
        Task<PaginationResultDto<HierarchyDto>> GetAllPagingAsync(PagingFilterDto primeTable);
        Task<HierarchyDto> GetByIdAsync(int id);
    }
}
