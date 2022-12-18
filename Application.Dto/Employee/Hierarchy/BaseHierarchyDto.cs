namespace Application.Dto.Employee.Hierarchy
{
    public abstract class BaseHierarchyDto
    {
        public string Name { get; set; } = string.Empty;
        public int LevelId { get; set; }
    }
}
