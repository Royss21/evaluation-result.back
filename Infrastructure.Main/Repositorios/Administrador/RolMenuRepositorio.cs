using Infrastructure.Main.Repositorios.Administrador.Interfaces;

namespace Infrastructure.Main.Repositorios.Administrador
{
    public class RolMenuRepositorio : BaseRepositorio<RolMenu, int>, IRolMenuRepositorio
    {
        public RolMenuRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
