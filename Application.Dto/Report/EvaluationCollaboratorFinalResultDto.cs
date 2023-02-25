
namespace Application.Dto.Report
{
    using Application.Dto.EvaResult.EvaluationCollaborator;
    public class EvaluationCollaboratorFinalResultDto: CollaboratorInformationDto
    {
        public Guid EvaluationId { get; set; }
        public decimal FinalResult { get; set; }
        public string ResultLabel { get; set; } = string.Empty;
    }
}
