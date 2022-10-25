
namespace Domain.Main.Config
{
    using Domain.Main.Employee;
    public class SubcomponentValue : BaseModel<string>
    {
        public string SubcomponentId { get; set; } = string.Empty;
        public int? ChargeId { get; set; }
        public decimal RelativeWeight { get; set; }
        public decimal MinimunPercentage { get; set; }
        public decimal MaximunPercentage { get; set; }


        public Subcomponent Subcomponent { get; set; }
        public Charge? Charge { get; set; }
    }
}
