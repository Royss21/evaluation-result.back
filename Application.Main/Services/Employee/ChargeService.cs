using Application.Dto.Employee.Charge;
using Application.Main.Service.Base;
using Application.Main.Services.Employee.Interfaces;

namespace Application.Main.Services.Employee
{
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
    }
}
