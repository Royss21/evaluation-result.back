
namespace Application.Dto.Employee.Hierarchy
{
    using Application.Dto.Config.HierarchyComponent;
    using System.Text.Json.Serialization;
    public class HierarchyDto : BaseHierarchyDto
    {
        public int Id { get; set; }
        public string LevelName { get; set; } = string.Empty;
        public List<HierarchyComponentDto>? HierarchyComponents { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
