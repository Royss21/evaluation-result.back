using Infrastructure.Main.Repositorios.Entidades.Interfaces;

namespace Infrastructure.Main.Repositorios.Entidades
{
    public class TipoEntidadEstadoRepositorio : BaseRepositorio<TipoEntidadEstado, int>, ITipoEntidadEstadoRepositorio
    {
        public TipoEntidadEstadoRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
