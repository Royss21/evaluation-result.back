namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;

    public class ComponentStage : BaseModel<int>
    {
        public int IdEvaluationComponent { get; set; }
        public int IdStage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public EvaluationComponent EvaluationComponent  { get; set; }
        public Stage Stage { get; set; }
    }
}
