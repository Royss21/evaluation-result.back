using Application.Dto.EvaResult.EvaluationCollaborator;

namespace Application.Dto.Report
{
    public class EvaluationCollaboratorFinalResultDto: CollaboratorInformationDto
    {
        public Guid EvaluationId { get; set; }
        public decimal FinalResult { get; set; }
        public string ResultLabel { get; set; } = string.Empty;
    }
}
