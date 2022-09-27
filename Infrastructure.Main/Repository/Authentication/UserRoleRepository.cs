
namespace Infrastructure.Main.Repository.Authentication
{
    using Infrastructure.Main.Repository.Authentication.Interfaces;
    public class UserRoleRepository : BaseRepository<UserRole, int>, IUserRoleRepository
    {
        public UserRoleRepository(Contexto.DbContextMain dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
