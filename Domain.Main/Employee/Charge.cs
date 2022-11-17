using Domain.Main.EvaResult;

namespace Domain.Main.Employee
{
    public class Charge : BaseModel<int>
    {
        public Charge()
        {
            Collaborators = new HashSet<Collaborator>();
        }

        public int AreaId { get; set; }
        public int HierarchyId { get; set; }
        public string Name { get; set; } = string.Empty;





        public virtual Area Area { get; set; }
        public virtual Hierarchy Hierarchy { get; set; }
        public virtual ICollection<Collaborator> Collaborators { get; set; }
    }
}

