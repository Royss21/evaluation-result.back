

namespace Domain.Main.Administrador
{
    using Domain.Main.Autenticacion;
    public class RolMenu : BaseModel<int>
    {
        public Guid RolId { get; set; }
        public Guid MenuId { get; set; }

        public Rol Rol { get; set; }
        public Menu Menu { get; set; }
    }
}