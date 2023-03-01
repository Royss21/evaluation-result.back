
namespace Application.Dto.Report
{
    using Application.Dto.EvaResult.EvaluationCollaborator;
    using System.Text.Json.Serialization;

    public class EvaluationCollaboratorFinalResultDto: CollaboratorInformationDto
    {
        public Guid EvaluationId { get; set; }
        public decimal FinalResult { get; set; }
        public string ResultLabel { get; set; } = string.Empty;

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
