namespace Application.Main.Services.Security.Interfaces
{
    using Application.Dto.Pagination;
    using Application.Dto.Security.Role;

    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllAsync();
        Task<RoleDto> CreateAsync(RoleCreateDto request);
        Task<bool> UpdateAsync(RoleUpdateDto request);
        Task<bool> DeleteAsync(int id);
        Task<PaginationResultDto<RoleDto>> GetAllPagingAsync(PagingFilterDto primeTable);

    }
}
