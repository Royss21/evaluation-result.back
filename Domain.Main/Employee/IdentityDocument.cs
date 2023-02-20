namespace Domain.Main.Employee
{
    public class IdentityDocument : BaseModel<int>
    {
        public IdentityDocument()
        {
            Collaborators = new HashSet<Collaborator>();
        }
        public string Name { get; set; } = string.Empty;


        public virtual ICollection<Collaborator> Collaborators { get; set; }
    }
}

