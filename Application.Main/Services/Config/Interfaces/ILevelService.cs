namespace Application.Main.Services.Config.Interfaces
{
    using Application.Dto.Config.Level;
    using Application.Dto.Pagination;

    public interface ILevelService
    {
        Task<IEnumerable<LevelDto>> GetAllAsync();
        Task<PaginationResultDto<LevelDto>> GetAllPagingAsync(PagingFilterDto primeTable);
        Task<LevelDto> GetByIdAsync(int id);
        Task<LevelDto> CreateAsync(LevelCreateDto request);
        Task<bool> UpdateAsync(LevelUpdateDto request);
        Task<bool> DeleteAsync(int id);
        Task<LevelDependencyDto> HasDependencyOtherEntitiesAsync(int levelId);
    }
}
