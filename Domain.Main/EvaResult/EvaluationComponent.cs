namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;

    public class EvaluationComponent : BaseModel<int>
    {
        public int IdEvaluation { get; set; }
        public int IdComponent { get; set; }


        public Evaluation? Evaluation { get; set; }
        public Component? Component { get; set; }
    }
}
