
namespace Domain.Main.Autenticacion
{

    public  class UsuarioRol : BaseModel<int>
    {
        public Guid UsuarioId { get; set; }
        public Guid RolId { get; set; }

        public Usuario Usuario { get; set; }
        public Rol Rol { get; set; }

    }
}
