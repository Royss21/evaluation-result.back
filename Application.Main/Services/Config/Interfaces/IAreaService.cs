namespace Application.Main.Services.Config.Interfaces
{
    using Application.Dto.Config.Area;
    using Application.Dto.Pagination;
    using Application.Main.PrimeNg;

    public interface IAreaService
    {
        Task<IEnumerable<AreaResDto>> GetAll();
        Task<PaginationResultDto<AreaResDto>> GetAllPaging(PrimeTable primeTable);
        Task<AreaResDto> GetById(int id);
        Task<bool> CreateAsync(AreaCreateReqDto request);
        Task<bool> UpdateAsync(AreaUpdateReqDto request);
        Task<bool> DeleteAsync(int id);
    }
}
