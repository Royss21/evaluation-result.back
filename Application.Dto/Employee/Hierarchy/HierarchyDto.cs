
namespace Application.Dto.Employee.Hierarchy
{
    using System.Text.Json.Serialization;
    public class HierarchyDto : BaseHierarchyDto
    {
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
