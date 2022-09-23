using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class ProductoSetRepositorio : BaseRepositorio<ProductoSet, int>, IProductoSetRepositorio
    {
        public ProductoSetRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
