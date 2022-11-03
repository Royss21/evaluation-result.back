namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;

    public class EvaluationComponent : BaseModel<int>
    {
        public EvaluationComponent()
        {
            ComponentsCollaborator = new HashSet<ComponentCollaborator>();
            EvaluationComponentStages = new HashSet<EvaluationComponentStage>();
        }

        public Guid EvaluationId { get; set; }
        public int ComponentId { get; set; }
        public int StatusId { get; set; }





        public virtual Evaluation Evaluation { get; set; }
        public virtual Component Component { get; set; }
        public virtual ICollection<EvaluationComponentStage> EvaluationComponentStages { get; set; }
        public virtual ICollection<ComponentCollaborator> ComponentsCollaborator { get; set; }
    }
}
