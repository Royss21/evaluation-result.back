
namespace Application.Main.Services.Security
{
    using Application.Dto.Security.User;
    using Application.Main.Service.Base;
    using Application.Main.Services.Security.Interfaces;
    using Application.Security.Password;
    using Domain.Main.Security;

    public class UserService : BaseService, IUserService
    {
        private readonly IPasswordFactory _passwordFactory;
        public UserService(IPasswordFactory passwordFactory, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _passwordFactory = passwordFactory;
        }

        public async Task<UserDto> CreateAsync(UserCreateDto request)
        {
            (int hashType, string passwordHash) = _passwordFactory.Hash(request.Password);

            var user = _mapper.Map<User>(request);
            user.HashType = hashType;
            user.Password = passwordHash;

            user.UserRoles = request.RolesId.Select(roleId => new UserRole { RoleId = roleId }).ToList();

            await _unitOfWorkApp.Repository.UserRepository.AddAsync(user);
            await _unitOfWorkApp.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            return await _unitOfWorkApp.Repository.UserRepository
                    .All()
                    .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
        }
    }
}
