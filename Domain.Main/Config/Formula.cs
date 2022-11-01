namespace Domain.Main.Config
{
    public class Formula : BaseModel<Guid>
    {
        public Formula()
        {
            Subcomponents = new HashSet<Subcomponent>();
        }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FormulaReal { get; set; } = string.Empty;
        public string FormulaQuery { get; set; } = string.Empty;






        public virtual ICollection<Subcomponent> Subcomponents { get; set; }
    }
}
