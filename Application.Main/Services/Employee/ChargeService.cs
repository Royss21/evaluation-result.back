namespace Application.Main.Services.Employee
{
    using Domain.Main.Employee;
    using System.ComponentModel;
    using Domain.Common.Constants;
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
                throw new ValidatorException(string.Join(",", resultValidator.Errors.Select(e => e.ErrorMessage)));

            await _unitOfWorkApp.SaveChangesAsync();
            return _mapper.Map<ChargeDto>(charge);
        }

        public async Task<bool> UpdateAsync(ChargeUpdateDto request)
        {
            var charge = _mapper.Map<Charge>(request);
            var resultValidator = await _unitOfWorkApp.Repository.ChargeRepository
                .UpdateAsync(charge, new ChargeCreateUpdateValidation(_unitOfWorkApp.Repository.ChargeRepository));

            if (!resultValidator.IsValid)
                throw new ValidatorException(string.Join(",", resultValidator.Errors.Select(e => e.ErrorMessage)));

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
    }
}
