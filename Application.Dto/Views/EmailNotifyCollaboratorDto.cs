namespace Application.Dto.Views
{
    public class EmailNotifyCollaboratorDto
    {
        public string FullName { get; set; } = string.Empty;
        public string EvaluationCollaboratorId { get; set; } = string.Empty;
        public string RangeDateStageApproval { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid EvaluationId { get; set; }
    }
}
