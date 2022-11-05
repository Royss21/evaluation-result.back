namespace Application.Dto.EvaResult.LeaderCollaborator
{
    public abstract class BaseLeaderCollaboratorDto
    {
        public int LeaderStageId { get; set; }
        public Guid? EvaluationCollaboratorId { get; set; }
    }
}
