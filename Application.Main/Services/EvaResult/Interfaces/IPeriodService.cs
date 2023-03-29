namespace Application.Main.Services.EvaResult.Interfaces
{
    using Application.Dto.EvaResult.Period;
    using Application.Dto.Pagination;
    using Application.Main.PrimeNg;

    public interface IPeriodService
    {
        Task<IEnumerable<PeriodDto>> GetAllAsync();
        Task<PaginationResultDto<PeriodDto>> GetAllPagingAsync(PagingFilterDto primeTable);
        Task<PeriodDto> GetByIdAsync(int id);
        Task<PeriodDto> CreateAsync(PeriodCreateDto request);
        Task<bool> UpdateAsync(PeriodUpdateDto request);
        Task<bool> DeleteAsync(int id);
        Task<PeriodInProgressDto> GetPeriodInProgressAsync();
        Task<PeriodDto> GetCurrentDatePeriodAsync();
        Task<bool> CheckExistEvaluationInProgress(int id);

    }
}
