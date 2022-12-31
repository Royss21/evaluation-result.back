namespace Domain.Main.Security
{
    public class RoleMenu : BaseModel<int>
    {
        public int RoleId { get; set; }
        public int MenuId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Menu Menu { get; set; }
    }
}