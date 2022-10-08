namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;


    public class LeaderStage : BaseModel<int>
    {
        public int IdEvaluationLeader { get; set; }
        public int IdStage { get; set; }


        public EvaluationLeader? EvaluationLeader { get; set; }
        public Stage? Stage { get; set; }
    }
}
