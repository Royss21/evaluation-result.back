namespace Application.Main.Services.Config.Interfaces
{
    using Application.Dto.Config.ParameterRange;
    using Application.Dto.Pagination;

    public interface IParameterRangeService
    {
        Task<PaginationResultDto<ParameterRangeDto>> GetAllPagingAsync(PagingFilterDto primeTable);
        Task<ParameterRangeDto> GetByIdAsync(Guid id);
        Task<ParameterRangeDto> CreateAsync(ParameterRangeCreateDto request);
        Task<bool> UpdateAsync(ParameterRangeUpdateDto request);
        Task<bool> DeleteAsync(Guid id);
    }
}
