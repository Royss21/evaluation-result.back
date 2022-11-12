namespace Application.Dto.EvaResult.ParameterValue
{
    public abstract class BaseParameterValueDto
    {
        public Guid RangeParameterId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public string NameProperty { get; set; } = string.Empty;
    }
}
