namespace Domain.Main.Security
{

    public class UserRole : BaseModel<int>
    {
        public string UserId { get; set; }
        public int RoleId { get; set; }

        public User? User { get; set; }
        public Role? Role { get; set; }

    }
}
