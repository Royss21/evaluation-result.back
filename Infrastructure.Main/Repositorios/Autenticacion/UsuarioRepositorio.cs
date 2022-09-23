using Infrastructure.Main.Repositorios.Autenticacion.Interfaces;

namespace Infrastructure.Main.Repositorios.Autenticacion
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario, Guid>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
