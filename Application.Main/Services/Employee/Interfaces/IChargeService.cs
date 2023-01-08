using Application.Dto.Employee.Charge;
using Application.Dto.Pagination;

namespace Application.Main.Services.Employee.Interfaces
{
    public interface IChargeService
    {
        Task<IEnumerable<ChargeDto>> GetAllAsync();
        Task<PaginationResultDto<ChargeDto>> GetAllPagingAsync(PagingFilterDto primeTable);
        Task<ChargeDto> GetByIdAsync(int id);
        Task<ChargeDto> CreateAsync(ChargeCreateDto request);
        Task<bool> UpdateAsync(ChargeUpdateDto request);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ChargeDto>> GetByIdAreaAsync(int id);
    }
}
