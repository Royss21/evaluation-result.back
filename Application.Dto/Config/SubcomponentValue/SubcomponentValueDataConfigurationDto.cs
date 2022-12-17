
namespace Application.Dto.Config.SubcomponentValue
{
    public class SubcomponentValueDataConfigurationDto 
    {
        public Guid SubcomponentId { get; set; }
        public string ChargeName { get; set; } = string.Empty;
        public decimal RelativeWeight { get; set; }
        public decimal MinimunPercentage { get; set; }
        public decimal MaximunPercentage { get; set; }
    }
}
