
namespace Application.Dto.Employee.Collaborator
{
    using System.Text.Json.Serialization;
    public class CollaboratorDto : BaseCollaboratorDto
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
        public int AreaId { get; set; }
        public int GerencyId { get; set; }
        public string ChargeName { get; set; } = string.Empty;
        public string HierarchyName { get; set; } = string.Empty;
        public string GerencyName { get; set; } = string.Empty;
        public string AreaName { get; set; } = string.Empty;
        public string LevelName { get; set; } = string.Empty;
    }
}
