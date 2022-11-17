namespace Application.Main.Services.Config.Interfaces
{
    using Application.Dto.Config.HierarchyComponent;
    using Application.Dto.Pagination;

    public interface IHierarchyComponentService
    {
        Task<PaginationResultDto<HierarchyComponentPagingDto>> GetAllPagingAsync(PagingFilterDto primeTable);
        Task<List<HierarchyComponentDto>> GetByHierarchAsync(int hierarchyId);
        Task<bool> CreateBulkAsync(List<HierarchyComponentCreateDto> request);
        Task<bool> UpdateBulkAsync(List<HierarchyComponentUpdateDto> request);
        Task<bool> DeleteByHierarchyAsync(int hierarchyId);
    }
}
