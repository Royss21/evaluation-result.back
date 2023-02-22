
namespace Application.Main.Services.Security.Interfaces
{
    using Application.Dto.Pagination;
    using Domain.Main.Security;

    public interface IAuditService
    {
        Task<IEnumerable<AuditEntity>> GetAllAsync();
        Task<PaginationResultDto<AuditEntity>> GetAllPagingAsync(PagingFilterDto primeTable);
    }
}