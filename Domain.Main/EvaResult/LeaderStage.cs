namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;


    public class LeaderStage : BaseModel<int>
    {
        public int EvaluationLeaderId { get; set; }
        public int StageId { get; set; }


        public EvaluationLeader EvaluationLeader { get; set; }
        public Stage Stage { get; set; }
    }
}
