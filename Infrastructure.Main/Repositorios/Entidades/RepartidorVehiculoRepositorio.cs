using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class RepartidorVehiculoRepositorio : BaseRepositorio<RepartidorVehiculo, Guid>, IRepartidorVehiculoRepositorio
    {
        public RepartidorVehiculoRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
