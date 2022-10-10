namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;

    public class EvaluationStage : BaseModel<int>
    {
        public string IdEvaluation { get; set; } = string.Empty;
        public int IdStage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public Evaluation Evaluation { get; set; }
        public Stage Stage { get; set; }
    }
}
