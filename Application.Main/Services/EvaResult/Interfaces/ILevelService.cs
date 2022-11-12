namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.EvaResult.Evaluation;

    public interface ILevelService
    {
        Task<IEnumerable<PeriodDto>> GetAllAsync();
        Task<PaginationResultDto<PeriodDto>> GetAllPagingAsync(PrimeTable primeTable);
        Task<PeriodDto> GetByIdAsync(int id);
        Task<PeriodDto> CreateAsync(PeriodCreateDto request);
        Task<bool> UpdateAsync(PeriodUpdateDto request);
        Task<bool> DeleteAsync(int id);
    }
}
