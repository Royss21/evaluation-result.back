
namespace Domain.Main.Config
{
    using Domain.Main.Employee;
    public class HierarchyComponent : BaseModel<int>
    {
        public int IdHierarchy { get; set; }
        public int IdComponent { get; set; }
        public decimal Weight { get; set; }


        public Hierarchy Hierarchy { get; set; }
        public Component Component { get; set; }
    }
}
