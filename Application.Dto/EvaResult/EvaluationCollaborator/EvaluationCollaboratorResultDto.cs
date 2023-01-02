
namespace Application.Dto.EvaResult.Evaluation
{
    using Application.Dto.EvaResult.ComponentCollaborator;
    using Application.Dto.EvaResult.EvaluationCollaborator;

    public class EvaluationCollaboratorResultDto : CollaboratorInformationDto
    {
        public Guid Id { get; set; }
        public int EvaluationComponentStageId { get; set; }
        public int ComponentCollaboratorCommentId { get; set; }
        public int StageId { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string FeedbackComment { get; set; } = string.Empty;
        public string ApprovalComment { get; set; } = string.Empty;
        public IEnumerable<ComponentCollaboratorResultDto> ResultComponents { get; set; }
    }
}
