namespace Domain.Main.Security
{
    public class Role : BaseModel<int>
    {
        public Role()
        {
            RolesMenu = new HashSet<RoleMenu>();
            UserRoles = new HashSet<UserRole>();
        }

        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;


        public virtual ICollection<RoleMenu> RolesMenu { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
