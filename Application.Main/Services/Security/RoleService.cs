namespace Application.Main.Services.Security
{
    using Domain.Main.Security;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Application.Dto.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.Pagination;
    using Application.Dto.Security.Role;
    using Application.Main.Service.Base;
    using Application.Main.Services.Security.Interfaces;
    using Application.Main.Services.Security.Validators;
    using Domain.Common.Constants;

    public class RoleService : BaseService, IRoleService
    {
        public RoleService(IServiceProvider serviceProvider) : base(serviceProvider)
        { }

        public async Task<RoleDto> CreateAsync(RoleCreateDto request)
        {
            var role = _mapper.Map<Role>(request);

            var resultValidator = await _unitOfWorkApp.Repository.RoleRepository
                .AddAsync(role, new RoleValidator(_unitOfWorkApp.Repository.RoleRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(". \n", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return _mapper.Map<RoleDto>(role);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var role = await _unitOfWorkApp.Repository.RoleRepository.GetAsync(id);

            if (role is null)
                throw new System.ComponentModel.WarningException(Messages.General.ResourceNotFound);

            await _unitOfWorkApp.Repository.RoleRepository.DeleteAsync(role);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            var role = await _unitOfWorkApp.Repository.RoleRepository
                .All()
                .ProjectTo<RoleDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return role;
        }

        public async Task<PaginationResultDto<RoleDto>> GetAllPagingAsync(PagingFilterDto primeTable)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<RoleDto>.Convert(primeTable);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<Role, RoleDto>(_mapper);

            if (!string.IsNullOrWhiteSpace(primeTable.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add => add.Name.ToLower().Contains(primeTable.GlobalFilter.ToLower()));
            }

            var paging = await _unitOfWorkApp.Repository.RoleRepository.FindAllPagingAsync(parametersDomain);
            var roles = await paging.Entities.ProjectTo<RoleDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginationResultDto<RoleDto>
            {
                Count = paging.Count,
                Entities = roles
            };
        }

        public async Task<bool> UpdateAsync(RoleUpdateDto request)
        {
            var role = _mapper.Map<Role>(request);
            var resultValidator = await _unitOfWorkApp.Repository.RoleRepository
                .UpdateAsync(role, new RoleValidator(_unitOfWorkApp.Repository.RoleRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(". \n", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }
    }
}
