using Infrastructure.Main.Repositorios.Administrador.Interfaces;

namespace Infrastructure.Main.Repositorios.Administrador
{
    public class MenuRepositorio : BaseRepositorio<Menu, Guid>, IMenuRepositorio
    {
        public MenuRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
