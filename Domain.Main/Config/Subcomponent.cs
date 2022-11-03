
namespace Domain.Main.Config
{
    using Domain.Main.Employee;

    public class Subcomponent : BaseModel<Guid>
    {
        public Subcomponent()
        {
            Conducts = new HashSet<Conduct>();
            SubcomponentValues = new HashSet<SubcomponentValue>();
        }
        
        public int ComponentId { get; set; }
        public int? AreaId { get; set; }
        public Guid? FormulaId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        




        public virtual Component Component { get; set; }
        public virtual Area? Area { get; set; }
        public virtual Formula? Formula { get; set; }
        public virtual ICollection<SubcomponentValue> SubcomponentValues { get; set; }
        public virtual ICollection<Conduct> Conducts { get; set; }
    }
}
