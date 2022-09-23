using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class ClienteDireccionEnvioRepositorio : BaseRepositorio<ClienteDireccionEnvio, Guid>, IClienteDireccionEnvioRepositorio
    {
        public ClienteDireccionEnvioRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
