namespace Domain.Main.Employee
{
    public class Charge : BaseModel<int>
    {
        public int AreaId { get; set; }
        public int HierarchyId { get; set; }
        public string Name { get; set; } = string.Empty;


        public Area Area { get; set; }
        public Hierarchy Hierarchy { get; set; }
    }
}
