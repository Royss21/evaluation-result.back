namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;

    public class ComponentStages : BaseModel<int>
    {
        public int IdEvaluationComponent { get; set; }
        public int IdStage { get; set; }
        public string DateStart { get; set; } = string.Empty;
        public string DateEnd { get; set; } = string.Empty;


        public EvaluationComponent? EvaluationComponent  { get; set; }
        public Stage? Stage { get; set; }
    }
}
