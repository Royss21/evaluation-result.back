using Infrastructure.Main.Repositorios.Autenticacion.Interfaces;

namespace Infrastructure.Main.Repositorios.Autenticacion
{
    public class UsuarioTokenRepositorio : BaseRepositorio<UsuarioToken, Guid>, IUsuarioTokenRepositorio
    {
        public UsuarioTokenRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
