namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;

    public class EvaluationStage : BaseModel<int>
    {
        public Guid EvaluationId { get; set; }
        public int StageId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }





        public virtual Evaluation Evaluation { get; set; }
        public virtual Stage Stage { get; set; }
    }
}
