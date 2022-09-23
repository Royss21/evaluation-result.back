using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class MarcaVehiculoRepositorio : BaseRepositorio<MarcaVehiculo, int>, IMarcaVehiculoRepositorio
    {
        public MarcaVehiculoRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
