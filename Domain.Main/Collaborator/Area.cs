namespace Domain.Main.Collaborator
{
    public class Area : BaseModel<int>
    {
        public int IdGerency { get; set; }
        public string Name { get; set; } = string.Empty;


        public Gerency? Gerency { get; set; }
    }
}
