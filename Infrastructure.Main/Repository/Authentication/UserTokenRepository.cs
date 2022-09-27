

namespace Infrastructure.Main.Repository.Authentication
{
    using Infrastructure.Main.Repository.Authentication.Interfaces;
    public class UserTokenRepository : BaseRepository<UserToken, Guid>, IUserTokenRepository
    {
        public UserTokenRepository(Contexto.DbContextMain dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
