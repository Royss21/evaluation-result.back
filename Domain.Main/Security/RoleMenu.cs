namespace Domain.Main.Security
{
    public class RoleMenu : BaseModel<int>
    {
        public int RoleId { get; set; }
        public int MenuId { get; set; }

        public Role? Role { get; set; }
        public Menu? Menu { get; set; }
    }
}