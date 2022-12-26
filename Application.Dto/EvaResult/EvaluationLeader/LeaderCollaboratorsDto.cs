namespace Application.Dto.EvaResult.EvaluationLeader
{
    public class LeaderCollaboratorsDto
    {
        public Guid EvaluationCollaboratorId { get; set; }
        public string CollaboratorName { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public List<string> StagesName { get; set; }
        public string AreaName { get; set; } = string.Empty;
    }
}
