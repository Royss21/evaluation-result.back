

namespace Infrastructure.Main.Repositorios.Administrador
{
    using Infrastructure.Main.Repository.Admin.Interfaces;
    public class RoleMenuRepository : BaseRepository<RoleMenu, int>, IRoleMenuRepositorio
    {
        public RoleMenuRepository(Contexto.DbContextMain dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
