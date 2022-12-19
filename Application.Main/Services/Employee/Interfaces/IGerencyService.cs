
namespace Application.Main.Services.Employee.Interfaces
{
    using Application.Dto.Pagination;
    using Application.Dto.Employee.Gerency;

    public interface IGerencyService
    {
        Task<IEnumerable<GerencyDto>> GetAllAsync();
        Task<PaginationResultDto<GerencyDto>> GetAllPagingAsync(PagingFilterDto primeTable);
    }
}
