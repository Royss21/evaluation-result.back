namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;

    public class ComponentCollaborator : BaseModel<Guid>
    {
        public ComponentCollaborator()
        {
            ComponentCollaboratorDetails = new HashSet<ComponentCollaboratorDetail>();
        }

        public int EvaluationComponentId { get; set; }
        public Guid EvaluationCollaboratorId { get; set; }
        public string ComponentName { get; set; } = string.Empty;
        public string HierarchyName { get; set; } = string.Empty;
        public decimal WeightHierarchy { get; set; }
        public decimal SubTotal { get; set; }
        public decimal ExcessSubtotal { get; set; }
        public decimal Total { get; set; }
        public decimal TotalCalibrated { get; set; }
        public decimal Excess { get; set; }
        public int StatusId { get; set; }



        public virtual Status Status { get; set; }
        public virtual EvaluationComponent EvaluationComponent { get; set; }
        public virtual EvaluationCollaborator EvaluationCollaborator { get; set; }
        public virtual ICollection<ComponentCollaboratorDetail> ComponentCollaboratorDetails { get; set; }
    }
}
