
namespace Application.Main.Services.Security.Interfaces
{
    using Application.Dto.Pagination;
    using Domain.Main.Security;

    public interface ILogService
    {
        Task<bool> CreateAsync(LogEntity request);
        Task<IEnumerable<LogEntity>> GetAllAsync();
        Task<PaginationResultDto<LogEntity>> GetAllPagingAsync(PagingFilterDto primeTable);
    }
}