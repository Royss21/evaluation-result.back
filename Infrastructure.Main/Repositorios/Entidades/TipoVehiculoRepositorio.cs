using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class TipoVehiculoRepositorio : BaseRepositorio<TipoVehiculo, int>, ITipoVehiculoRepositorio
    {
        public TipoVehiculoRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
