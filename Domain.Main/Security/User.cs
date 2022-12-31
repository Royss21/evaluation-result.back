namespace Domain.Main.Security
{
    public class User : BaseModelActive<Guid>
    {
        public User()
        {
            UserEndpointsLocked = new HashSet<UserEndpointLocked>();
            UserRoles = new HashSet<UserRole>();
        }

        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int TypeHash { get; set; }
        public bool IsLocked { get; set; }

        public virtual ICollection<UserEndpointLocked> UserEndpointsLocked { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual UserToken UserToken { get; set; }
    }
}
