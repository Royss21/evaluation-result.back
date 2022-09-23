using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class PedidoHistorialRepositorio : BaseRepositorio<PedidoHistorial, int>, IPedidoHistorialRepositorio
    {
        public PedidoHistorialRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
