using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class RepartidorPrecioRepositorio : BaseRepositorio<RepartidorPrecio, Guid>, IRepartidorPrecioRepositorio
    {
        public RepartidorPrecioRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
