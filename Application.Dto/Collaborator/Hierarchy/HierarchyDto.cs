
namespace Application.Dto.Employee.Hierarchy
{
    using System.Text.Json.Serialization;
    public class HierarchyDto : BaseHierarchyDto
    {
        public int Id { get; set; }

        [JsonIgnore]
        public DateTimeOffset CreateDate { get; set; }
    }
}
