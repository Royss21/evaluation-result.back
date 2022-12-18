namespace Application.Main.Services.Employee
{
    using System.ComponentModel;
    using Application.Main.Service.Base;
    using Application.Dto.Employee.Charge;
    using Application.Main.Services.Employee.Interfaces;
    using Domain.Common.Constants;

    public class ChargeService : BaseService, IChargeService
    {
        public ChargeService(IServiceProvider serviceProvider) : base(serviceProvider) { }

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
                throw new WarningException(Messages.General.ResourceNotFound);

            return charge;
        }

    }
}
