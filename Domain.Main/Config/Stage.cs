using Domain.Main.EvaResult;

namespace Domain.Main.Config
{
    public  class Stage : BaseModel<int>
    {
        public Stage()
        {
            EvaluationStages = new HashSet<EvaluationStage>();
            ComponentStages = new HashSet<ComponentStage>();
            ComponentCollaboratorStages = new HashSet<ComponentCollaboratorStage>();
            LeaderStages = new HashSet<LeaderStage>();
        }

        public string Name { get; set; } = string.Empty;





        public virtual ICollection<EvaluationStage> EvaluationStages { get; set; }
        public virtual ICollection<ComponentStage> ComponentStages { get; set; }
        public virtual ICollection<ComponentCollaboratorStage> ComponentCollaboratorStages { get; set; }
        public virtual ICollection<LeaderStage> LeaderStages { get; set; }
    }
}
