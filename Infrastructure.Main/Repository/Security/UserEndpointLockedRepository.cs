
namespace Infrastructure.Main.Repository.Security
{
    using Infrastructure.Data.MainModule.Repository;
    using Infrastructure.Main.Repository.Security.Interfaces;
    public class UserEndpointLockedRepository : BaseRepository<UserEndpointLocked, int>, IUserEndpointLockedRepository
    {
        public UserEndpointLockedRepository(DbContextMain dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
