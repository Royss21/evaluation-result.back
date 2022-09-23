using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class ProductoPrecioRepositorio : BaseRepositorio<ProductoPrecio, Guid>, IProductoPrecioRepositorio
    {
        public ProductoPrecioRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
