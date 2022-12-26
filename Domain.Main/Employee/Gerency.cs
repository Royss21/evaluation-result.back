using Domain.Main.EvaResult;

namespace Domain.Main.Employee
{
    public class Gerency : BaseModel<int>
    {
        public Gerency()
        {
            Areas = new HashSet<Area>();
        }

        public string Name { get; set; } = string.Empty;


        public virtual ICollection<Area> Areas { get; set; }
    }
}
