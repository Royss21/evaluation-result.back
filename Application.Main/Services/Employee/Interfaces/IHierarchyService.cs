namespace Application.Main.Services.Employee.Interfaces
{
    using Application.Dto.Employee.Hierarchy;
    public interface IHierarchyService
    {
        Task<IEnumerable<HierarchyDto>> GetAllAsync();
        Task<HierarchyDto> GetByIdAsync(int id);
    }
}
