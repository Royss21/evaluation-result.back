namespace Application.Main.Services.Employee
{
    using Domain.Main.Employee;
    using Domain.Common.Constants;
    using Application.Dto.Pagination;
    using Application.Main.Pagination;
    using Application.Main.Exceptions;
    using Application.Main.Service.Base;
    using Application.Dto.Employee.Charge;
    using Application.Main.Services.Employee.Interfaces;
    using Application.Main.Services.Employee.Validators;

    public class ChargeService : BaseService, IChargeService
    {
        public ChargeService(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public async Task<ChargeDto> CreateAsync(ChargeCreateDto request)
        {
            var charge = _mapper.Map<Charge>(request);
            var resultValidator = await _unitOfWorkApp.Repository.ChargeRepository
                .AddAsync(charge, new ChargeCreateUpdateValidation(_unitOfWorkApp.Repository.ChargeRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(". \n", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();
            return _mapper.Map<ChargeDto>(charge);
        }

        public async Task<bool> UpdateAsync(ChargeUpdateDto request)
        {
            var charge = _mapper.Map<Charge>(request);
            var resultValidator = await _unitOfWorkApp.Repository.ChargeRepository
                .UpdateAsync(charge, new ChargeCreateUpdateValidation(_unitOfWorkApp.Repository.ChargeRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(". \n", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ChargeDto>> GetAllAsync()
        {
            var charge = await _unitOfWorkApp.Repository.ChargeRepository
                .All()
                .ProjectTo<ChargeDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return charge;
        }

        public async Task<ChargeDto> GetByIdAsync(int id)
        {
            var charge = await _unitOfWorkApp.Repository.ChargeRepository
                   .Find(c => c.Id == id)
                   .ProjectTo<ChargeDto>(_mapper.ConfigurationProvider)
                   .FirstOrDefaultAsync();

            if (charge is null)
                throw new System.ComponentModel.WarningException(Messages.General.ResourceNotFound);

            return charge;
        }

        public async Task<IEnumerable<ChargeDto>> GetByIdAreaAsync(int id)
        {
            var charge = await _unitOfWorkApp.Repository.ChargeRepository
                   .Find(c => c.AreaId == id)
                   .ProjectTo<ChargeDto>(_mapper.ConfigurationProvider)
                   .ToListAsync();

            if (charge is null)
                throw new Exceptions.WarningException(Messages.General.ResourceNotFound);

            return charge;
        }

        public async Task<PaginationResultDto<ChargeDto>> GetAllPagingAsync(PagingFilterDto primeTable)
        {
            var parametersDto = PrimeNgToPaginationParametersDto<ChargeDto>.Convert(primeTable);
            var parametersDomain = parametersDto.ConvertToPaginationParameterDomain<Charge, ChargeDto>(_mapper);

            if (!string.IsNullOrWhiteSpace(primeTable.GlobalFilter))
            {
                parametersDomain.FilterWhere = parametersDomain.FilterWhere
                        .AddCondition(add => add.Name.ToLower().Contains(primeTable.GlobalFilter.ToLower()));
            }

            var paging = await _unitOfWorkApp.Repository.ChargeRepository.FindAllPagingAsync(parametersDomain);
            var charges = await paging.Entities.ProjectTo<ChargeDto>(_mapper.ConfigurationProvider).ToListAsync();

            return new PaginationResultDto<ChargeDto>
            {
                Count = paging.Count,
                Entities = charges
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var charge = await _unitOfWorkApp.Repository.ChargeRepository.GetAsync(id);

            if (charge is null)
                throw new System.ComponentModel.WarningException(Messages.General.ResourceNotFound);

            await _unitOfWorkApp.Repository.ChargeRepository.DeleteAsync(charge);
            await _unitOfWorkApp.SaveChangesAsync();

            return true;
        }
    }
}
