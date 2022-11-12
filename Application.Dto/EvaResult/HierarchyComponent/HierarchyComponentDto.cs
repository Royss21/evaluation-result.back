
namespace Application.Dto.EvaResult.HierarchyComponent
{
    using System.Text.Json.Serialization;
    public class HierarchyComponentDto : BaseHierarchyComponentDto
    {
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
