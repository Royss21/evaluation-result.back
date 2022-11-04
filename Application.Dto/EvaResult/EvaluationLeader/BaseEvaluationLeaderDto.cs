namespace Application.Dto.EvaResult.EvaluationLeader
{
    public abstract class BaseEvaluationLeaderDto
    {
        public Guid EvaluationCollaboratorId { get; set; }
        public int? AreaId { get; set; }
        public Guid EvaluationId { get; set; }
    }
}
