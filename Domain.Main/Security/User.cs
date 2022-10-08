namespace Domain.Main.Security
{
    public class User : BaseModelActive<Guid>
    {
        public Guid PersonId { get; set; }
        public string NameUser { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int TypeHash { get; set; }
        public bool IsLocked { get; set; }

        //public Persona Persona { get; set; }
    }
}
