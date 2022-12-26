using Domain.Main.Employee;
using Domain.Main.EvaResult;

namespace Domain.Main.Config
{
    public class Level : BaseModel<int>
    {
        public Level()
        {
            Hierarchies = new HashSet<Hierarchy>();
            Conducts = new HashSet<Conduct>();
        }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;





        public virtual ICollection<Hierarchy> Hierarchies { get; set; }
        public virtual ICollection<Conduct> Conducts { get; set; }
    }
}
