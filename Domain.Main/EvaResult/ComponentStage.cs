namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;

    public class ComponentStage : BaseModel<int>
    {
        public int EvaluationComponentId { get; set; }
        public int StageId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }





        public virtual EvaluationComponent EvaluationComponent  { get; set; }
        public virtual Stage Stage { get; set; }
    }
}
