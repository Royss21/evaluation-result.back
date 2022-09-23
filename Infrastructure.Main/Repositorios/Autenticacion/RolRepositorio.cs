using Infrastructure.Main.Repositorios.Autenticacion.Interfaces;

namespace Infrastructure.Main.Repositorios.Autenticacion
{
    public class RolRepositorio : BaseRepositorio<Rol, Guid>, IRolRepositorio
    {
        public RolRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
