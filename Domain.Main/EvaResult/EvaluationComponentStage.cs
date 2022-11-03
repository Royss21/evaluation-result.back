namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;

    public class EvaluationComponentStage : BaseModel<int>
    {
        public EvaluationComponentStage()
        {
            ComponentCollaboratorStages = new HashSet<ComponentCollaboratorStage>();
        }

        public Guid EvaluationId { get; set; }
        public int? EvaluationComponentId { get; set; }
        public int StageId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }





        public virtual Evaluation Evaluation { get; set; }
        public virtual Stage Stage { get; set; }
        public virtual EvaluationComponent? EvaluationComponent { get; set; }
        public virtual ICollection<ComponentCollaboratorStage> ComponentCollaboratorStages { get; set; }
    }
}
