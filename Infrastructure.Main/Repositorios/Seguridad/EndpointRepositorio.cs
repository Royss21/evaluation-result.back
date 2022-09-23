using Infrastructure.Main.Repositorios.Seguridad.Interfaces;

namespace Infrastructure.Main.Repositorios.Seguridad
{
    public class EndpointRepositorio : BaseRepositorio<Endpoint, Guid>, IEndpointRepositorio
    {
        public EndpointRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
