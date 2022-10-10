namespace Domain.Main.EvaResult
{
    public class LeaderCollaborator : BaseModel<int>
    {
        public int IdLeaderStage { get; set; }
        public int IdEvaluationCollaborator { get; set; }


        public LeaderStage LeaderStage { get; set; }
        public EvaluationCollaborator EvaluationCollaborator { get; set; }
    }
}
