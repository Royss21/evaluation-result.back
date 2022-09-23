

namespace Infrastructure.UnitOfWork.Interfaces
{
    using Infrastructure.Main.Repositorios.Administrador.Interfaces;
    using Infrastructure.Main.Repositorios.Autenticacion.Interfaces;
    using Infrastructure.Main.Repositorios.Entidades.Interfaces;
    using Infrastructure.Main.Repositorios.Seguridad.Interfaces;

    public interface IUnitOfWorkRepositorio
    {
        ICategoriaRepositorio CategoriaRepositorio { get; }
        IClienteDireccionEnvioRepositorio ClienteDireccionEnvioRepositorio { get; }
        IClienteRepositorio ClienteRepositorio { get; }
        IColorRepositorio ColorRepositorio { get; }
        ICompaniaRepositorio CompaniaRepositorio { get; }
        ICotizacionRepositorio CotizacionRepositorio { get; }
        ICotizacionDetalleRepositorio CotizacionDetalleRepositorio { get; }
        IDocumentoIdentidadRepositorio DocumentoIdentidadRepositorio { get; }
        IEstadoRepositorio EstadoRepositorio { get; }
        IFormaPagoRepositorio FormaPagoRepositorio { get; }
        IImagenRepositorio ImagenRepositorio { get; }
        IMarcaVehiculoRepositorio MarcaVehiculoRepositorio { get; }
        IMenuRepositorio MenuRepositorio { get; }
        IOperadoraTelefonoRepositorio OperadoraTelefonoRepositorio { get; }
        IPedidoCuotaRepositorio PedidoCuotaRepositorio { get; }
        IPedidoDetalleRepositorio PedidoDetalleRepositorio { get; }
        IPedidoHistorialRepositorio PedidoHistorialRepositorio { get; }
        IPedidoRepositorio PedidoRepositorio { get; }
        IPersonaRepositorio PersonaRepositorio { get; }
        IPersonaTelefonoRepositorio PersonaTelefonoRepositorio { get; }
        IProductoCategoriaRepositorio ProductoCategoriaRepositorio { get; }
        IProductoFotoRepositorio ProductoFotoRepositorio { get; }
        IProductoPrecioRepositorio ProductoPrecioRepositorio { get; }
        IProductoRepositorio ProductoRepositorio { get; }
        IProductoSetRepositorio ProductoSetRepositorio { get; }
        IRepartidorPrecioRepositorio RepartidorPrecioRepositorio { get; }
        IRepartidorRepositorio RepartidorRepositorio { get; }
        IRepartidorVehiculoRepositorio RepartidorVehiculoRepositorio { get; }
        IRolMenuRepositorio RolMenuRepositorio { get; }
        IRolRepositorio RolRepositorio { get; }
        ITamanioRepositorio TamanioRepositorio { get; }
        ITelaRepositorio TelaRepositorio { get; }
        ITelaColorRepositorio TelaColorRepositorio { get; }
        ITipoEntidadEstadoRepositorio TipoEntidadEstadoRepositorio { get; }
        ITipoVehiculoRepositorio TipoVehiculoRepositorio { get; }
        IUbigeoRepositorio UbigeoRepositorio { get; }
        IUsuarioEndpointBloqueadoRepositorio UsuarioEndpointBloqueadoRepositorio { get; }
        IEndpointRepositorio EndpointRepositorio { get; }
        IUsuarioRepositorio UsuarioRepositorio { get; }
        IUsuarioRolRepositorio UsuarioRolRepositorio { get; }
        IUsuarioTokenRepositorio UsuarioTokenRepositorio { get; }
    }
}
