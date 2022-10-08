namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;

    public class EvaluationStages : BaseModel<int>
    {
        public int IdEvaluation { get; set; }
        public int IdStage { get; set; }
        public string DateStart { get; set; } = string.Empty;
        public string DateEnd { get; set; } = string.Empty;


        public Evaluation? Evaluation { get; set; }
        public Stage? Stage { get; set; }
    }
}
