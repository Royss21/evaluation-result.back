namespace Infrastructure.Main.Repository.Security
{
    using Domain.Main.Security;
    using Infrastructure.Main.Repository.Security.Interfaces;

    public class RoleRepository : BaseRepository<Role, Guid>, IRoleRepository
    {
        public RoleRepository(DbContextMain dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
