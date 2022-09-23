using Domain.Main.Autenticacion;

namespace Domain.Main.Seguridad
{
    public class UsuarioEnpointBloqueado : BaseModelo<int>
    {
        public Guid UsuarioId { get; set; }
        public Guid EndpointId { get; set; }

        public Usuario Usuario { get; set; }
        public Endpoint Endpoint { get; set; }
    }
}
