
namespace Application.Dto.EvaResult.ComponentCollaborator
{
    using Application.Dto.EvaResult.ComponentCollaboratorDetail;
    public class ComponentCollaboratorResultDto
    {
        public int ComponentId { get; set; }
        public int EvaluationComponentId { get; set; }
        public string EvaluationComment { get; set; } = string.Empty;
        public string CalibrationComment { get; set; } = string.Empty;
        public decimal WeightHierarchy { get; set; }
        public decimal SubTotal { get; set; }
        public decimal SubTotalCalibrated { get; set; }
        public decimal ExcessSubtotal { get; set; }
        public decimal ComplianceCompetence { get; set; }
        public decimal ComplianceCompetenceCalibrated { get; set; }
        public decimal Total { get; set; }
        public decimal TotalCalibrated { get; set; }
        public decimal Excess { get; set; }

        public List<ComponentCollaboratorDetailResultDto> ResultObjectives { get; set; }
    }
}
