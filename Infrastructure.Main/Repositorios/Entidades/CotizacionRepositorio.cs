using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class CotizacionRepositorio : BaseRepositorio<Cotizacion, Guid>, ICotizacionRepositorio
    {
        public CotizacionRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
