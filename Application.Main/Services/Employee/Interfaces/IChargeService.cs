using Application.Dto.Employee.Charge;

namespace Application.Main.Services.Employee.Interfaces
{
    public interface IChargeService
    {
        Task<IEnumerable<ChargeDto>> GetAllAsync();
    }
}
