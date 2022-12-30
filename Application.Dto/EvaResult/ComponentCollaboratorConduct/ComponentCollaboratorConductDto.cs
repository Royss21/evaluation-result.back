namespace Application.Dto.EvaResult.ComponentCollaboratorConduct
{
    public class ComponentCollaboratorConductDto
    {
        public int Id { get; set; }
        public string ConductDescription { get; set; } = string.Empty;
        public decimal PointValue { get; set; }
        public decimal PointValueCalibrated { get; set; }
    }
}
