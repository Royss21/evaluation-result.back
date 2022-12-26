namespace Infrastructure.Main.Repository.Security
{
    using Infrastructure.Main.Repository.Security.Interfaces;
    public class EndpointRepository : BaseRepository<EndpointService, Guid>, IEndpointRepository
    {
        public EndpointRepository(DbContextMain dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
