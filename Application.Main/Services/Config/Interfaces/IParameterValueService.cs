namespace Application.Main.Services.Config.Interfaces
{
    using Application.Dto.Config.ParameterValue;
    using Application.Dto.Pagination;

    public interface IParameterValueService
    {
        Task<PaginationResultDto<ParameterValueDto>> GetAllPagingAsync(ParameterValueFilterDto filter);
        Task<List<ParameterValueDto>> GetAllByParameterRangeAsync(Guid parameterRangeId);
        Task<ParameterValueDto> CreateAsync(ParameterValueCreateDto request);
        Task<bool> UpdateAsync(ParameterValueUpdateDto request);
        Task<bool> DeleteAsync(int id);
    }
}
