namespace Application.Dto.EvaResult.SubcomponentValue
{
    public abstract class BaseSubcomponentValueDto
    {
        public Guid SubcomponentId { get; set; }
        public int? ChargeId { get; set; }
        public decimal RelativeWeight { get; set; }
        public decimal MinimunPercentage { get; set; }
        public decimal MaximunPercentage { get; set; }
    }
}
