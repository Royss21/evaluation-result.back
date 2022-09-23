using Infrastructure.Main.Repositorios.Seguridad.Interfaces;

namespace Infrastructure.Main.Repositorios.Seguridad
{
    public class UsuarioEndpointBloqueadoRepositorio : BaseRepositorio<UsuarioEnpointBloqueado, int>, IUsuarioEndpointBloqueadoRepositorio
    {
        public UsuarioEndpointBloqueadoRepositorio(DbContextoPrincipal dbContextoPrincipal) : base(dbContextoPrincipal)
        {

        }
    }
}
