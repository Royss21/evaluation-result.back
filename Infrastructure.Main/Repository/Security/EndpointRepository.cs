namespace Infrastructure.Main.Repositorios.Seguridad
{
    using Infrastructure.Data.MainModule.Repository;
    using Infrastructure.Main.Repository.Security.Interfaces;
    public class EndpointRepository : BaseRepository<Endpoint, Guid>, IEndpointRepository
    {
        public EndpointRepository(Contexto.DbContextMain dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
