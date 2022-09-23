using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class UbigeoRepositorio : BaseRepositorio<Ubigeo, int>, IUbigeoRepositorio
    {
        public UbigeoRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
