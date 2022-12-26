namespace Domain.Main.EvaResult
{
    public class LeaderCollaborator : BaseModel<int>
    {
        public int LeaderStageId { get; set; }
        public Guid EvaluationCollaboratorId { get; set; }





        public virtual LeaderStage LeaderStage { get; set; }
        public virtual EvaluationCollaborator EvaluationCollaborator { get; set; }
    }
}
