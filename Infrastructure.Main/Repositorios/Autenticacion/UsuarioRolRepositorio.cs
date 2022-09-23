using Infrastructure.Main.Repositorios.Autenticacion.Interfaces;

namespace Infrastructure.Main.Repositorios.Autenticacion
{
    public class UsuarioRolRepositorio : BaseRepositorio<UsuarioRol, int>, IUsuarioRolRepositorio
    {
        public UsuarioRolRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
