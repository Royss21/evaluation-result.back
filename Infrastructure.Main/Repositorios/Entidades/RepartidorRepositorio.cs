using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class RepartidorRepositorio : BaseRepositorio<Repartidor, Guid>, IRepartidorRepositorio
    {
        public RepartidorRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
