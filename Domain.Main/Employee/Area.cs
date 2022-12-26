using Domain.Main.Config;
using Domain.Main.EvaResult;

namespace Domain.Main.Employee
{
    public class Area : BaseModel<int>
    {
        public Area()
        {
            Charges = new HashSet<Charge>();
            Subcomponents = new HashSet<Subcomponent>();
        }

        public int GerencyId { get; set; }
        public string Name { get; set; } = string.Empty;





        public virtual Gerency Gerency { get; set; }
        public virtual ICollection<Charge> Charges { get; set; }
        public virtual ICollection<Subcomponent> Subcomponents { get; set; }
    }
}
