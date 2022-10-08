namespace Infrastructure.Main.Repository.Security
{
    using Domain.Main.Security;
    using Infrastructure.Main.Repository.Security.Interfaces;

    public class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        public UserRepository(DbContextMain dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
