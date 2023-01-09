
namespace Application.Dto.EvaResult.EvaluationCollaborator
{
    using System.Text.Json.Serialization;
    public class EvaluationCollaboratorReviewPagingDto : BaseEvaluationCollaboratorDto
    {
        public Guid Id { get; set; }
        public string CollaboratorName { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public int StatusId { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
