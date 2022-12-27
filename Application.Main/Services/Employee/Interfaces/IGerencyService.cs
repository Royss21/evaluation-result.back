
namespace Application.Main.Services.Employee.Interfaces
{
    using Application.Dto.Pagination;
    using Application.Dto.Employee.Gerency;

    public interface IGerencyService
    {
        Task<IEnumerable<GerencyDto>> GetAllAsync();
        Task<GerencyDto> CreateAsync(GerencyCreateDto request);
        Task<bool> UpdateAsync(GerencyUpdateDto request);
        Task<bool> DeleteAsync(int id);
        Task<PaginationResultDto<GerencyDto>> GetAllPagingAsync(PagingFilterDto primeTable);
    }
}
