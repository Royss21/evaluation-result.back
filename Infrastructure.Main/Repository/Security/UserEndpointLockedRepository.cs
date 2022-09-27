
namespace Infrastructure.Main.Repositorios.Seguridad
{
    using Infrastructure.Data.MainModule.Repository;
    using Infrastructure.Main.Repository.Security.Interfaces;
    public class UserEndpointLockedRepository : BaseRepository<UserEndpointLocked, int>, IUserEndpointLockedRepository
    {
        public UserEndpointLockedRepository(Contexto.DbContextMain dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
