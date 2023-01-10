
namespace Application.Dto.Config.HierarchyComponent
{
    using System.Text.Json.Serialization;
    public class HierarchyComponentPagingDto
    {
        public int HierarchyId { get; set; }
        public string HierarchyName { get; set; } = string.Empty;
        public string LevelName { get; set; } = string.Empty;
        public List<HierarchyOnlyComponent>? Components { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }

}
