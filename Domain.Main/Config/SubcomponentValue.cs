
namespace Domain.Main.Config
{
    using Domain.Main.Employee;
    public class SubcomponentValue : BaseModel<Guid>
    {
        public Guid SubcomponentId { get; set; }
        public int? ChargeId { get; set; }
        public decimal RelativeWeight { get; set; }
        public decimal MinimunPercentage { get; set; }
        public decimal MaximunPercentage { get; set; }





        public virtual Subcomponent Subcomponent { get; set; }
        public virtual Charge? Charge { get; set; }
    }
}
