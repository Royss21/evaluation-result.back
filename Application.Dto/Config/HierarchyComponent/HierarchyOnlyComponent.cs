namespace Application.Dto.Config.HierarchyComponent
{
    public class HierarchyOnlyComponent
    {
        public int ComponentId { get; set; }
        public string ComponentName { get; set; } = string.Empty;
        public decimal Weight { get; set; }

        public HierarchyOnlyComponent(int componentId, string componentName, decimal weight)
        {
            this.ComponentId = componentId;
            this.ComponentName = componentName;
            this.Weight = weight;
        }
    }
}
