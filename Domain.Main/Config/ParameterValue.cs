namespace Domain.Main.Config
{
    public class ParameterValue : BaseModel<int>
    {
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public string NameProperty { get; set; } = string.Empty;
        public Guid RangeParameterId { get; set; }




        public RangeParameter RangeParameter { get; set; }
    }
}
