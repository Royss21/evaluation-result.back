using Domain.Main.EvaResult;

namespace Domain.Main.Config
{
    public class Status : BaseModel<int>
    {
        public Status()
        {
            ComponentsCollaborator = new HashSet<ComponentCollaborator>();
            ComponentCollaboratorComments = new HashSet<ComponentCollaboratorComment>();
            Evaluations = new HashSet<Evaluation>();
            EvaluationComponents = new HashSet<EvaluationComponent>();
        }

        public string Name { get; set; } = string.Empty;


        public virtual ICollection<ComponentCollaborator> ComponentsCollaborator { get; set; }
        public virtual ICollection<ComponentCollaboratorComment> ComponentCollaboratorComments { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; }
        public virtual ICollection<EvaluationComponent> EvaluationComponents { get; set; }
        
    }
}
