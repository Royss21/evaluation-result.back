namespace Application.Dto.EvaResult.EvaluationLeader
{
    public abstract class BaseEvaluationLeaderDto
    {
        public Guid EvaluationCollaboratorId { get; set; }
        public Guid EvaluationId { get; set; }
        public int EvaluationComponentId { get; set; }
        public string AreaName { get; set; } = string.Empty;
    }
}
