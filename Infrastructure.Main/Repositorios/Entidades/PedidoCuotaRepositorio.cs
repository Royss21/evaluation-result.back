using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class PedidoCuotaRepositorio : BaseRepositorio<PedidoCuota, Guid>, IPedidoCuotaRepositorio
    {
        public PedidoCuotaRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
