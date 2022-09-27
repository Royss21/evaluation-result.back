

namespace Infrastructure.Main.Repositorios.Administrador
{

    using Infrastructure.Main.Repository.Admin.Interfaces;
    public class MenuRepository : BaseRepository<Menu, Guid>, IMenuRepository
    {
        public MenuRepository(Contexto.DbContextMain dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
