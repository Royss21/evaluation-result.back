
namespace Infrastructure.Main.Repository.Authentication
{
    using Infrastructure.Main.Repository.Authentication.Interfaces;
    public class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        public UserRepository(DbContextMain dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
