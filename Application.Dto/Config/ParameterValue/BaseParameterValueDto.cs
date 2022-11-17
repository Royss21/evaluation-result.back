namespace Application.Dto.Config.ParameterValue
{
    public abstract class BaseParameterValueDto
    {
        public Guid ParameterRangeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }
    }
}
