
namespace Application.Dto.EvaResult.EvaluationCollaborator
{
    using System.Text.Json.Serialization;
    public class EvaluationCollaboratorEvaluatePagingDto : BaseEvaluationCollaboratorDto
    {
        public Guid Id { get; set; }
        public Guid ComponentCollaboratorId { get; set; }
        public string CollaboratorName { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;

        [JsonIgnore]
        public DateTime CreateDate { get; set; }

        [JsonIgnore]
        public Dictionary<int, Guid> ComponentCollaboratorIds { get; set; }
    }
}
