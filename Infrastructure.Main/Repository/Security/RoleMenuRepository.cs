namespace Infrastructure.Main.Repository.Security
{
    using Domain.Main.Security;
    using Infrastructure.Main.Repository.Security.Interfaces;

    public class RoleMenuRepository : BaseRepository<RoleMenu, int>, IRoleMenuRepository
    {
        public RoleMenuRepository(DbContextMain dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
