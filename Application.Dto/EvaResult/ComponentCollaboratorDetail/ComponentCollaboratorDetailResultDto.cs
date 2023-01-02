
namespace Application.Dto.EvaResult.ComponentCollaboratorDetail
{
    using Application.Dto.EvaResult.ComponentCollaboratorConduct;
    public class ComponentCollaboratorDetailResultDto
    {
        public string SubcomponentName { get; set; } = string.Empty;
        public decimal WeightRelative { get; set; }
        public decimal MinimunPercentage { get; set; }
        public decimal MaximunPercentage { get; set; }
        public decimal Result { get; set; }
        public decimal Compliance { get; set; }
        public decimal Points { get; set; }
        public decimal PointsCalibrated { get; set; }

        public IEnumerable<ComponentCollaboratorConductResultDto> ResultConducts { get; set; }

    }
}
