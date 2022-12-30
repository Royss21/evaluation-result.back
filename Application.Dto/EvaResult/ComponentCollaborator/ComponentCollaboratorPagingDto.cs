
namespace Application.Dto.EvaResult.ComponentCollaborator
{
    using System.Text.Json.Serialization;

    public class ComponentCollaboratorPagingDto
    {
        public Guid Id { get; set; }
        public string CollaboratorName { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public string GerencyName { get; set; } = string.Empty;
        public string ChargeName { get; set; } = string.Empty;
        public string AreaName { get; set; } = string.Empty;
        public string HierarchyName { get; set; } = string.Empty;
        public string LevelName { get; set; } = string.Empty;
        public int StatusId { get; set; }

        [JsonIgnore] public DateTime CreateDate { get; set; }
        [JsonIgnore]  public int ComponentId { get; set; }
        [JsonIgnore]  public Guid EvaluationCollaboratorId { get; set; }
        [JsonIgnore] public int EvaluationComponentId { get; set; }

    }
}
