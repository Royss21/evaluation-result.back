namespace Domain.Main.EvaResult
{
    public class LeaderCollaborator : BaseModel<int>
    {
        public int LeaderStageId { get; set; }
        public string EvaluationCollaboratorId { get; set; }


        public LeaderStage LeaderStage { get; set; }
        public EvaluationCollaborator EvaluationCollaborator { get; set; }
    }
}
