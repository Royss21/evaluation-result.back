namespace Application.Dto.EvaResult.ComponentCollaborator
{
    public abstract class BaseComponentCollaboratorDto
    {
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
    }
}
