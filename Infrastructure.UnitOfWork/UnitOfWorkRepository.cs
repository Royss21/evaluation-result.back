
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

    public class UnitOfWorkRepository : IUnitOfWorkRepositorio
    {
        //public ICategoriaRepositorio CategoriaRepositorio { get; }

        public UnitOfWorkRepository(DbContextoPrincipal contextPrincipal)
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