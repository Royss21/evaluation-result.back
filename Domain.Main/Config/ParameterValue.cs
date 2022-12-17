namespace Domain.Main.Config
{
    public class ParameterValue : BaseModel<int>
    {
        public Guid ParameterRangeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Value { get; set; }
        public string NameProperty { get; set; } = string.Empty;
        public string EntityName { get; set; } = string.Empty;



        public ParameterRange ParameterRange { get; set; }
    }
}
