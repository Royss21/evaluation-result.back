
namespace Application.Main.Services.Security.Interfaces
{
    using Application.Dto.Pagination;
    using Application.Dto.Security.User;
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserResponseDto> CreateAsync(UserCreateDto request);
        Task<bool> UpdateAsync(UserUpdateDto request);
        Task<bool> DeleteAsync(Guid id);
        Task<PaginationResultDto<UserDto>> GetAllPagingAsync(PagingFilterDto primeTable);
    }
}