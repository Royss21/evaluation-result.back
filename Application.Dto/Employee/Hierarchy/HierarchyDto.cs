
namespace Application.Dto.Employee.Hierarchy
{
    using System.Text.Json.Serialization;
    public class HierarchyDto : BaseHierarchyDto
    {
        public int Id { get; set; }
        public string LevelName { get; set; } = string.Empty;

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
