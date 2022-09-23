using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class TamanioRepositorio : BaseRepositorio<Tamanio, int>, ITamanioRepositorio
    {
        public TamanioRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
