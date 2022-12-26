
namespace Domain.Main.Config
{
    using Domain.Main.Employee;
    public class HierarchyComponent : BaseModel<int>
    {
        public int HierarchyId { get; set; }
        public int ComponentId { get; set; }
        public decimal Weight { get; set; }





        public virtual Hierarchy Hierarchy { get; set; }
        public virtual Component Component { get; set; }
    }
}
