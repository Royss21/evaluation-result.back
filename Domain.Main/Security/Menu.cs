namespace Domain.Main.Security
{
    public class Menu : BaseModelActive<int>
    {

        public Menu()
        {
            RolesMenu = new HashSet<RoleMenu>();
        }

        public int? MenuDadId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public int Sort { get; set; }
        public Menu? MenuDad { get; set; }



        public virtual ICollection<RoleMenu> RolesMenu { get; set; }
    }
}