
namespace Application.Main.Services.Security
{
    using Domain.Main.Security;
    using Domain.Common.Constants;
    using Application.Dto.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.Pagination;
    using Application.Dto.Security.User;
    using Application.Main.Service.Base;
    using Application.Security.Password;
    using Application.Main.Services.Security.Interfaces;
    using Application.Main.Services.Security.Validators;

    public class UserService : BaseService, IUserService
    {
        private readonly IPasswordFactory _passwordFactory;
        public UserService(IPasswordFactory passwordFactory, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _passwordFactory = passwordFactory;
        }

        public async Task<UserResponseDto> CreateAsync(UserCreateDto request)
        {
            (int hashType, string passwordHash) = _passwordFactory.Hash(request.Password);

            var user = _mapper.Map<User>(request);

            var resultValidator = await _unitOfWorkApp.Repository.UserRepository.AddAsync(
                user, new UserCreateValidator(_unitOfWorkApp.Repository.UserRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(". \n", resultValidator.Errors.Select(e => e.ErrorMessage)));

            user.HashType = hashType;
            user.Password = passwordHash;

            user.UserRoles = request.RolesId.Select(roleId => new UserRole { RoleId = roleId }).ToList();

            await _unitOfWorkApp.Repository.UserRepository.AddAsync(user);
            await _unitOfWorkApp.SaveChangesAsync();

            return _mapper.Map<UserResponseDto>(user);
        }

        public async Task<bool> UpdateAsync(UserUpdateDto request)
        {
            var user = _mapper.Map<User>(request);
            //var userExists = await _unitOfWorkApp.Repository.UserRepository
            //    .Find(f => f.Id.Equals(request.Id), false)
            //    .FirstAsync();

            //userExists.UserName = user.UserName;
            //userExists.Names = user.Names;
            //userExists.LastName = user.LastName;
            //userExists.MiddleName = user.MiddleName;
            //userExists.Email = user.Email;
            //var resultValidator = await _unitOfWorkApp.Repository.UserRepository.UpdateAsync(
            //    user, new UserUpdateValidator(_unitOfWorkApp.Repository.UserRepository));

            //if (!resultValidator.IsValid)
            //    throw new ValidatorException(string.Join(". \n", resultValidator.Errors.Select(e => e.ErrorMessage)));

            //userExists.UserRoles = request.RolesId.Select(roleId => new UserRole { RoleId = roleId }).ToList();

            var userRoles = await _unitOfWorkApp.Repository.UserRoleRepository
                .Find(f => f.UserId.Equals(user.Id))
                .ToListAsync();

            foreach(var role in userRoles)
            {
                if (!request.RolesId.Contains(role.RoleId))
                    await _unitOfWorkApp.Repository.UserRoleRepository.DeleteAsync(role);
            }

            foreach (var roleId in request.RolesId)
            {
                if (!userRoles.Select(s => s.RoleId).Contains(roleId))
                    await _unitOfWorkApp.Repository.UserRoleRepository.AddAsync(new UserRole { UserId = user.Id, RoleId = roleId });
            }

            await _unitOfWorkApp.Repository.UserRepository.UpdateAsync(user);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await _unitOfWorkApp.Repository.UserRepository.GetAsync(id);

            if (user is null)
                throw new WarningException(Messages.General.ResourceNotFound);

            await _unitOfWorkApp.Repository.UserRepository.DeleteAsync(user);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            return await _unitOfWorkApp.Repository.UserRepository
                    .All()
                    .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
        }

        public async Task<PaginationResultDto<UserDto>> GetAllPagingAsync(PagingFilterDto primeTable)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<UserDto>.Convert(primeTable);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<User, UserDto>(_mapper);

            if (!string.IsNullOrWhiteSpace(primeTable.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add => add.Names.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                            add.LastName.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                            add.MiddleName.ToLower().Contains(primeTable.GlobalFilter.ToLower()) ||
                            add.Email.ToLower().Contains(primeTable.GlobalFilter.ToLower()));
            }

            var paging = await _unitOfWorkApp.Repository.UserRepository.FindAllPagingAsync(parametersDomain);
            var users = await paging.Entities.ProjectTo<UserDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginationResultDto<UserDto>
            {
                Count = paging.Count,
                Entities = users
            };
        }
    }
}
