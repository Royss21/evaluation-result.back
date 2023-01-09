
namespace Application.Dto.EvaResult.ComponentCollaborator
{
    using Application.Dto.EvaResult.EvaluationCollaborator;
    using System.Text.Json.Serialization;

    public class ComponentCollaboratorPagingDto : CollaboratorInformationDto
    {
        public Guid Id { get; set; }
        public int StatusId { get; set; }

        [JsonIgnore] public DateTime CreateDate { get; set; }
        [JsonIgnore]  public int ComponentId { get; set; }
        [JsonIgnore]  public Guid EvaluationCollaboratorId { get; set; }
        [JsonIgnore] public int EvaluationComponentId { get; set; }

    }
}
