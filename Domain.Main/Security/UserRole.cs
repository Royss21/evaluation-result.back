namespace Domain.Main.Security
{

    public class UserRole : BaseModel<int>
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }

    }
}
