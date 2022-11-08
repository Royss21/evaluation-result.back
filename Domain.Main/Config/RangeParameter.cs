namespace Domain.Main.Config
{
    public class RangeParameter : BaseModel<Guid>
    {
        public RangeParameter()
        {
            ParametersValue = new HashSet<ParameterValue>();
        }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsInternalConfiguration { get; set; }

        public virtual ICollection<ParameterValue> ParametersValue { get; set; }
    }
}
