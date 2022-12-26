using Domain.Main.EvaResult;

namespace Domain.Main.Config
{
    public  class Stage : BaseModel<int>
    {
        public Stage()
        {
            EvaluationStages = new HashSet<EvaluationComponentStage>();
            LeaderStages = new HashSet<LeaderStage>();
        }

        public string Name { get; set; } = string.Empty;





        public virtual ICollection<EvaluationComponentStage> EvaluationStages { get; set; }
        public virtual ICollection<LeaderStage> LeaderStages { get; set; }
    }
}
