
namespace Application.Main.Services.Security.Interfaces
{
    using Application.Dto.Security.User;
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> CreateAsync(UserCreateDto request);
    }
}
