using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class ProductoFotoRepositorio : BaseRepositorio<ProductoFoto, int>, IProductoFotoRepositorio
    {
        public ProductoFotoRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
