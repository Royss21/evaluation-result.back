
namespace Infrastructure.Main.Repository.Authentication
{
    using Infrastructure.Main.Repository.Authentication.Interfaces;

    public class RoleRepository : BaseRepository<Role, Guid>, IRoleRepository
    {
        public RoleRepository(Contexto.DbContextMain dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
