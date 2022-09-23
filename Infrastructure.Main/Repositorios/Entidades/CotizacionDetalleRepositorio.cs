using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class CotizacionDetalleRepositorio : BaseRepositorio<CotizacionDetalle, int>, ICotizacionDetalleRepositorio
    {
        public CotizacionDetalleRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
