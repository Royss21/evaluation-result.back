using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class PedidoDetalleRepositorio : BaseRepositorio<PedidoDetalle, int>, IPedidoDetalleRepositorio
    {
        public PedidoDetalleRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
