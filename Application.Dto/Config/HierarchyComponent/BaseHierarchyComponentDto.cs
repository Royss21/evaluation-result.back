namespace Application.Dto.Config.HierarchyComponent
{
    public abstract class BaseHierarchyComponentDto
    {
        public int HierarchyId { get; set; }
        public int ComponentId { get; set; }
        public decimal Weight { get; set; }
    }
}
