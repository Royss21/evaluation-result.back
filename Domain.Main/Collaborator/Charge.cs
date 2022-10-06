namespace Domain.Main.Collaborator
{
    public class Charge : BaseModel<int>
    {
        public int IdArea { get; set; }
        public int IdHierarchy { get; set; }
        public string Name { get; set; } = string.Empty;


        public Area Area { get; set; }
        public Hierarchy Hierarchy { get; set; }
    }
}
