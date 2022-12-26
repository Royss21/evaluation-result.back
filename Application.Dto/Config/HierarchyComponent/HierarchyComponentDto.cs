
namespace Application.Dto.Config.HierarchyComponent
{
    using System.Text.Json.Serialization;
    public class HierarchyComponentDto : BaseHierarchyComponentDto
    {
        public int Id { get; set; }
        public string HierarchyName { get; set; } = string.Empty;
        public string ComponentName { get; set; } = string.Empty;
    }
}
