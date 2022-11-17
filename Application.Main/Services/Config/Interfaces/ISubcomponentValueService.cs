namespace Application.Main.Services.Config.Interfaces
{
    using Application.Dto.Config.SubcomponentValue;
    using Application.Dto.Pagination;

    public interface ISubcomponentValueService
    {
        Task<List<SubcomponentValueDto>> GetAllBySubcomponentAsync(Guid subcomponentId);
        Task<SubcomponentValueDto> CreateAsync(SubcomponentValueCreateDto request);
        Task<bool> UpdateAsync(SubcomponentValueUpdateDto request);
        Task<bool> DeleteAsync(Guid id);
    }
}
