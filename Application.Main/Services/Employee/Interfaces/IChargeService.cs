using Application.Dto.Employee.Charge;

namespace Application.Main.Services.Employee.Interfaces
{
    public interface IChargeService
    {
        Task<IEnumerable<ChargeDto>> GetAllAsync();
        Task<ChargeDto> GetByIdAsync(int id);
        Task<ChargeDto> CreateAsync(ChargeCreateDto request);
        Task<bool> UpdateAsync(ChargeUpdateDto request);
        Task<IEnumerable<ChargeDto>> GetByIdAreaAsync(int id);
    }
}
