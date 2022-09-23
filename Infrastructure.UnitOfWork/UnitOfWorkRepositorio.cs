
namespace Infrastructure.UnitOfWork
{
    using Infrastructure.Main.Contexto;
    using Infrastructure.Main.Repositorios.Administrador.Interfaces;
    using Infrastructure.Main.Repositorios.Autenticacion.Interfaces;
    using Infrastructure.Main.Repositorios.Entidades.Interfaces;
    using Infrastructure.Main.Repositorios.Seguridad.Interfaces;
    using Infrastructure.Main.Repositorios.Entidades;
    using Infrastructure.Main.Repositorios.Seguridad;
    using Infrastructure.Main.Repositorios.Autenticacion;
    using Infrastructure.Main.Repositorios.Administrador;
    using Infrastructure.UnitOfWork.Interfaces;

    public class UnitOfWorkRepositorio : IUnitOfWorkRepositorio
    {
        public ICategoriaRepositorio CategoriaRepositorio { get; }
        public IClienteDireccionEnvioRepositorio ClienteDireccionEnvioRepositorio { get; }
        public IClienteRepositorio ClienteRepositorio { get; }
        public IColorRepositorio ColorRepositorio { get; }
        public ICompaniaRepositorio CompaniaRepositorio { get; }
        public ICotizacionDetalleRepositorio CotizacionDetalleRepositorio { get; }
        public ICotizacionRepositorio CotizacionRepositorio { get; }
        public IDocumentoIdentidadRepositorio DocumentoIdentidadRepositorio { get; }
        public IEstadoRepositorio EstadoRepositorio { get; }
        public IFormaPagoRepositorio FormaPagoRepositorio { get; }
        public IImagenRepositorio ImagenRepositorio { get; }
        public IMarcaVehiculoRepositorio MarcaVehiculoRepositorio { get; }
        public IMenuRepositorio MenuRepositorio { get; }
        public IOperadoraTelefonoRepositorio OperadoraTelefonoRepositorio { get; }
        public IPedidoCuotaRepositorio PedidoCuotaRepositorio { get; }
        public IPedidoDetalleRepositorio PedidoDetalleRepositorio { get; }
        public IPedidoRepositorio PedidoRepositorio { get; }
        public IPedidoHistorialRepositorio PedidoHistorialRepositorio { get; }
        public IPersonaRepositorio PersonaRepositorio { get; }
        public IPersonaTelefonoRepositorio PersonaTelefonoRepositorio { get; }
        public IProductoCategoriaRepositorio ProductoCategoriaRepositorio { get; }
        public IProductoFotoRepositorio ProductoFotoRepositorio { get; }
        public IProductoPrecioRepositorio ProductoPrecioRepositorio { get; }
        public IProductoRepositorio ProductoRepositorio { get; }
        public IProductoSetRepositorio ProductoSetRepositorio { get; }
        public IRepartidorPrecioRepositorio RepartidorPrecioRepositorio { get; }
        public IRepartidorRepositorio RepartidorRepositorio { get; }
        public IRepartidorVehiculoRepositorio RepartidorVehiculoRepositorio { get; }
        public IRolMenuRepositorio RolMenuRepositorio { get; }
        public IRolRepositorio RolRepositorio { get; }
        public ITamanioRepositorio TamanioRepositorio { get; }
        public ITelaRepositorio TelaRepositorio { get; }
        public ITelaColorRepositorio TelaColorRepositorio { get; }
        public ITipoEntidadEstadoRepositorio TipoEntidadEstadoRepositorio { get; }
        public ITipoVehiculoRepositorio TipoVehiculoRepositorio { get; }
        public IUbigeoRepositorio UbigeoRepositorio { get; }
        public IUsuarioEndpointBloqueadoRepositorio UsuarioEndpointBloqueadoRepositorio { get; }
        public IEndpointRepositorio EndpointRepositorio { get; }
        public IUsuarioRepositorio UsuarioRepositorio { get; }
        public IUsuarioRolRepositorio UsuarioRolRepositorio { get; }
        public IUsuarioTokenRepositorio UsuarioTokenRepositorio { get; }

        public UnitOfWorkRepositorio(DbContextoPrincipal contextPrincipal)
        {
            CategoriaRepositorio = new CategoriaRepositorio(contextPrincipal);
            ClienteDireccionEnvioRepositorio = new ClienteDireccionEnvioRepositorio(contextPrincipal);
            ClienteRepositorio = new ClienteRepositorio(contextPrincipal);
            ColorRepositorio = new ColorRepositorio(contextPrincipal);
            CompaniaRepositorio = new CompaniaRepositorio(contextPrincipal);
            CotizacionDetalleRepositorio = new CotizacionDetalleRepositorio(contextPrincipal);
            CotizacionRepositorio = new CotizacionRepositorio(contextPrincipal);
            DocumentoIdentidadRepositorio = new DocumentoIdentidadRepositorio(contextPrincipal);
            EstadoRepositorio = new EstadoRepositorio(contextPrincipal);
            FormaPagoRepositorio = new FormaPagoRepositorio(contextPrincipal);
            ImagenRepositorio = new ImagenRepositorio(contextPrincipal);
            MarcaVehiculoRepositorio = new MarcaVehiculoRepositorio(contextPrincipal);
            MenuRepositorio = new MenuRepositorio(contextPrincipal);
            OperadoraTelefonoRepositorio = new OperadoraTelefonoRepositorio(contextPrincipal);
            PedidoCuotaRepositorio = new PedidoCuotaRepositorio(contextPrincipal);
            PedidoDetalleRepositorio = new PedidoDetalleRepositorio(contextPrincipal);
            PedidoRepositorio = new PedidoRepositorio(contextPrincipal);
            PedidoHistorialRepositorio = new PedidoHistorialRepositorio(contextPrincipal);
            PersonaRepositorio = new PersonaRepositorio(contextPrincipal);
            PersonaTelefonoRepositorio = new PersonaTelefonoRepositorio(contextPrincipal);
            ProductoCategoriaRepositorio = new ProductoCategoriaRepositorio(contextPrincipal);
            ProductoFotoRepositorio = new ProductoFotoRepositorio(contextPrincipal);
            ProductoPrecioRepositorio = new ProductoPrecioRepositorio(contextPrincipal);
            ProductoRepositorio = new ProductoRepositorio(contextPrincipal);
            ProductoSetRepositorio = new ProductoSetRepositorio(contextPrincipal);
            RepartidorPrecioRepositorio = new RepartidorPrecioRepositorio(contextPrincipal);
            RepartidorRepositorio = new RepartidorRepositorio(contextPrincipal);
            RepartidorVehiculoRepositorio = new RepartidorVehiculoRepositorio(contextPrincipal);
            RolMenuRepositorio = new RolMenuRepositorio(contextPrincipal);
            RolRepositorio = new RolRepositorio(contextPrincipal);
            TamanioRepositorio = new TamanioRepositorio(contextPrincipal);
            TelaRepositorio = new TelaRepositorio(contextPrincipal);
            TelaColorRepositorio = new TelaColorRepositorio(contextPrincipal);
            TipoEntidadEstadoRepositorio = new TipoEntidadEstadoRepositorio(contextPrincipal);
            TipoVehiculoRepositorio = new TipoVehiculoRepositorio(contextPrincipal);
            UbigeoRepositorio = new UbigeoRepositorio(contextPrincipal);
            UsuarioEndpointBloqueadoRepositorio = new UsuarioEndpointBloqueadoRepositorio(contextPrincipal);
            EndpointRepositorio = new EndpointRepositorio(contextPrincipal);
            UsuarioRepositorio = new UsuarioRepositorio(contextPrincipal);
            UsuarioRolRepositorio = new UsuarioRolRepositorio(contextPrincipal);
            UsuarioTokenRepositorio = new UsuarioTokenRepositorio(contextPrincipal);
        }
    }
}