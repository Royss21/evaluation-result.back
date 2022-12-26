namespace Application.Main.Services.Config.Interfaces
{
    using Application.Dto.Config.Conduct;
    using Application.Dto.Pagination;

    public interface IConductService
    {
        Task<List<ConductDto>> GetAllBySubcomponentAsync(Guid subcomponentId);
        Task<ConductDto> CreateAsync(ConductCreateDto request);
        Task<bool> UpdateAsync(ConductUpdateDto request);
        Task<bool> DeleteAsync(Guid id);
    }
}
