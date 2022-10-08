namespace Domain.Main.Security
{
    public class RoleMenu : BaseModel<int>
    {
        public Guid RolId { get; set; }
        public Guid MenuId { get; set; }

        public Role? Role { get; set; }
        public Menu? Menu { get; set; }
    }
}