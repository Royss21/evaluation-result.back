

namespace Domain.Main.Admin
{

    using Domain.Main.Authentication;
    public class RoleMenu : BaseModel<int>
    {
        public Guid RolId { get; set; }
        public Guid MenuId { get; set; }

        public Role Role { get; set; }
        public Menu Menu { get; set; }
    }
}