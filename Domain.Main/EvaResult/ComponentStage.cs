namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;

    public class ComponentStage : BaseModel<int>
    {
        public int EvaluationComponentId { get; set; }
        public int StageId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public EvaluationComponent EvaluationComponent  { get; set; }
        public Stage Stage { get; set; }
    }
}
