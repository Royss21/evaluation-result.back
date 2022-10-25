namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;

    public class ComponentCollaborator : BaseModel<string>
    {
        public int EvaluationComponentId { get; set; }
        public string EvaluationCollaboratorId { get; set; } = string.Empty;
        public string ComponentName { get; set; } = string.Empty;
        public string HierarchyName { get; set; } = string.Empty;
        public decimal WeightHierarchy { get; set; }
        public decimal SubTotal { get; set; }
        public decimal SurplusSubtotal { get; set; }
        public decimal Total { get; set; }
        public decimal TotalCalibrated { get; set; }
        public decimal Surplus { get; set; }
        public string Comment { get; set; } = string.Empty;
        public string CommentCollaborator { get; set; } = string.Empty;


        public EvaluationComponent? EvaluationComponent { get; set; }
        public EvaluationCollaborator? EvaluationCollaborator { get; set; }
    }
}
