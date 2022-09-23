using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class ProductoCategoriaRepositorio : BaseRepositorio<ProductoCategoria, int>, IProductoCategoriaRepositorio
    {
        public ProductoCategoriaRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
