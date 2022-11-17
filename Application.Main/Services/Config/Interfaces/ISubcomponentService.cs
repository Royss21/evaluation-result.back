namespace Application.Main.Services.Config.Interfaces
{
    using Application.Dto.Config.Subcomponent;
    using Application.Dto.Pagination;

    public interface ISubcomponentService
    {
        Task<PaginationResultDto<SubcomponentDto>> GetAllPagingAsync(SubcomponentFilterDto primeTable);
        Task<SubcomponentDto> GetByIdAsync(Guid id);
        Task<SubcomponentDto> CreateAsync(SubcomponentCreateDto request);
        Task<bool> UpdateAsync(SubcomponentUpdateDto request);
        Task<bool> DeleteAsync(Guid id);
    }
}
