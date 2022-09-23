using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class CategoriaRepositorio : BaseRepositorio<Categoria, int>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
