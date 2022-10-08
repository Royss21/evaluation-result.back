namespace Domain.Main.EvaResult
{
    using Domain.Main.Config;

    public class ComponentCollaborator : BaseModel<int>
    {
        public int IdEvaluationComponent { get; set; }
        public int IdEvaluationCollaborator { get; set; }
        public int IdComponentHierarchy { get; set; }
        public int WeightHierarchy { get; set; }
        public double SubTotal { get; set; }
        public double SurplusSubtotal { get; set; }
        public double Total { get; set; }
        public double TotalCalibrated { get; set; }
        public double Surplus { get; set; }
        public string Comment { get; set; } = string.Empty;
        public string CommentCollaborator { get; set; } = string.Empty;
        public bool IsCompliant { get; set; }


        public EvaluationComponent? EvaluationComponent { get; set; }
        public EvaluationCollaborator? EvaluationCollaborator { get; set; }
        public HierarchyComponent? HierarchyComponent { get; set; }
    }
}
