using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class ClienteRepositorio : BaseRepositorio<Cliente, Guid>, IClienteRepositorio
    {
        public ClienteRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
