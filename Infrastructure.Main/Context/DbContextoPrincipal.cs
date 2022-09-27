

namespace Infrastructure.Main.Contexto
{
    using Domain.Common.Constantes;
    using Domain.Main.Base;
    using Infrastructure.Main.Contexto.Configuraciones.Administrador;
    using Infrastructure.Main.Contexto.Configuraciones.Auditoria;
    using Infrastructure.Main.Contexto.Configuraciones.Autenticacion;
    using Infrastructure.Main.Contexto.Configuraciones.Entidades;
    using Infrastructure.Main.Contexto.Configuraciones.Seguridad;

    public class DbContextoPrincipal : DbContext
    {
        private readonly Microsoft.AspNetCore.Http.IHttpContextAccessor _httpContextAccessor;
        private string NombreUsuarioActual { get; set; } = string.Empty;

        public DbContextoPrincipal(
            DbContextOptions<DbContextoPrincipal> options,
            Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor
        ): base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            NombreUsuarioActual = ObtenerNombreUsuarioActual();
        }

        public DbSet<AuditoriaEntidad> Auditoria { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ClienteDireccionEnvio> ClienteDireccionEnvio { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Compania> Compania { get; set; }
        public DbSet<Cotizacion> Cotizacion { get; set; }
        public DbSet<CotizacionDetalle> CotizacionDetalle { get; set; }
        public DbSet<DocumentoIdentidad> DocumentoIdentidad { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<FormaPago> FormaPago { get; set; }
        public DbSet<Imagen> Imagen { get; set; }
        public DbSet<MarcaVehiculo> MarcaVehiculo { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<OperadoraTelefono> OperadoraTelefono { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoCuota> PedidoCuota { get; set; }
        public DbSet<PedidoDetalle> PedidoDetalle { get; set; }
        public DbSet<PedidoHistorial> PedidoHistorial { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<PersonaTelefono> PersonaTelefono { get; set; }
        public DbSet<ProductoCategoria> ProductoCategoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<ProductoFoto> ProductoFoto { get; set; }
        public DbSet<ProductoPrecio> ProductoPrecio { get; set; }
        public DbSet<ProductoSet> ProductoSet { get; set; }
        public DbSet<Repartidor> Repartidor { get; set; }
        public DbSet<RepartidorPrecio> RepartidorPrecio { get; set; }
        public DbSet<RepartidorVehiculo> RepartidorVehiculo { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<RolMenu> RolMenu { get; set; }
        public DbSet<Tamanio> Tamanio { get; set; }
        public DbSet<Tela> Tela { get; set; }
        public DbSet<TelaColor> TelaColor { get; set; }
        public DbSet<TipoEntidadEstado> TipoEntidadEstado { get; set; }
        public DbSet<TipoVehiculo> TipoVehiculo { get; set; }
        public DbSet<Ubigeo> Ubigeo { get; set; }
        public DbSet<UsuarioEnpointBloqueado> UsuarioEnpointBloqueado { get; set; }
        public DbSet<Endpoint> Endpoint { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioToken> UsuarioToken { get; set; }
        public DbSet<UsuarioRol> UsuarioRol { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .ApplyConfiguration(new AuditoriaConfig())
                .ApplyConfiguration(new CategoriaConfig())
                .ApplyConfiguration(new ClienteConfig())
                .ApplyConfiguration(new CompaniaConfig())
                .ApplyConfiguration(new ClienteDireccionEnvioConfig())
                .ApplyConfiguration(new ColorConfig())
                .ApplyConfiguration(new CotizacionConfig())
                .ApplyConfiguration(new CotizacionDetalleConfig())
                .ApplyConfiguration(new DocumentoIdentidadConfig())
                .ApplyConfiguration(new EstadoConfig())
                .ApplyConfiguration(new EstadoConfig())
                .ApplyConfiguration(new FormaPagoConfig())
                .ApplyConfiguration(new ImagenConfig())
                .ApplyConfiguration(new FormaPagoConfig())
                .ApplyConfiguration(new MarcaVehiculoConfig())
                .ApplyConfiguration(new MenuConfig())
                .ApplyConfiguration(new OperadoraTelefonoConfig())
                .ApplyConfiguration(new PedidoConfig())
                .ApplyConfiguration(new PedidoCuotaConfig())
                .ApplyConfiguration(new PedidoDetalleConfig())
                .ApplyConfiguration(new PedidoHistorialConfig())
                .ApplyConfiguration(new PersonaConfig())
                .ApplyConfiguration(new PersonaTelefonoConfig())
                .ApplyConfiguration(new ProductoCategoriaConfig())
                .ApplyConfiguration(new ProductoConfig())
                .ApplyConfiguration(new ProductoFotoConfig())
                .ApplyConfiguration(new ProductoPrecioConfig())
                .ApplyConfiguration(new ProductoSetConfig())
                .ApplyConfiguration(new RepartidorConfig())
                .ApplyConfiguration(new RepartidorPrecioConfig())
                .ApplyConfiguration(new RepartidorVehiculoConfig())
                .ApplyConfiguration(new RolConfig())
                .ApplyConfiguration(new RolMenuConfig())
                .ApplyConfiguration(new TamanioConfig())
                .ApplyConfiguration(new TelaConfig())
                .ApplyConfiguration(new TelaColorConfig())
                .ApplyConfiguration(new TipoEntidadEstadoConfig())
                .ApplyConfiguration(new TipoVehiculoConfig())
                .ApplyConfiguration(new UbigeoConfig())
                .ApplyConfiguration(new UsuarioEnpointBloqueadoConfig())
                .ApplyConfiguration(new EndpointConfig())
                .ApplyConfiguration(new UsuarioConfig())
                .ApplyConfiguration(new UsuarioTokenConfig())
                .ApplyConfiguration(new UsuarioRolConfig());

            ConfigurarEntidades(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default(CancellationToken))
        {
            ActualizarEntidades();
            var auditoriaEntradas = AuditoriaAntesDeGuadarCambios();
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            await AuditoriaDespuesDeGuardarCambios(auditoriaEntradas);
            return result;
        }



        private List<AuditoriaEntrada> AuditoriaAntesDeGuadarCambios()
        {
            ChangeTracker.DetectChanges();
            var auditoriaEntradas = new List<AuditoriaEntrada>();

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is AuditoriaEntidad 
                     /*entry.Entity is LogSessionUser ||*/ 
                    || entry.State == EntityState.Detached 
                    || entry.State == EntityState.Unchanged)
                    continue;

                var auditoriaEntrada = new AuditoriaEntrada(entry)
                {
                    NombreTabla = entry.Metadata.GetTableName()
                };

                auditoriaEntradas.Add(auditoriaEntrada);

                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary)
                    {
                        auditoriaEntrada.PropiedadesTemporales.Add(property);
                        continue;
                    }

                    var propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditoriaEntrada.LlaveValores[propertyName] = property.CurrentValue ?? "";
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditoriaEntrada.ValoresNuevos[propertyName] = property.CurrentValue ?? "";
                            break;

                        case EntityState.Deleted:
                            auditoriaEntrada.ValoresAntiguos[propertyName] = property.OriginalValue ?? "";
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditoriaEntrada.ValoresAntiguos[propertyName] = property.OriginalValue ?? "";
                                auditoriaEntrada.ValoresNuevos[propertyName] = property.CurrentValue ?? "";
                            }

                            break;
                    }
                }
            }
            auditoriaEntradas.ForEach(ae =>
            {
                try
                {
                    if (!ae.TienePropiedadesTemporales)
                        Auditoria.Add(ae.MapAuditoria(NombreUsuarioActual));
                }
                catch (Exception) { }

            });

            return auditoriaEntradas.Where(entry => entry.TienePropiedadesTemporales).ToList();
        }
        private Task AuditoriaDespuesDeGuardarCambios(List<AuditoriaEntrada> auditoriaEntradas)
        {
            if (auditoriaEntradas is null || !auditoriaEntradas.Any())
                return Task.CompletedTask;

            foreach (var auditoriaEntrada in auditoriaEntradas)
            {
                foreach (var prop in auditoriaEntrada.PropiedadesTemporales)
                {
                    if (prop.Metadata.IsPrimaryKey())
                        auditoriaEntrada.LlaveValores[prop.Metadata.Name] = prop.CurrentValue ?? "";
                    else
                        auditoriaEntrada.ValoresNuevos[prop.Metadata.Name] = prop.CurrentValue ?? "";
                }

                try
                {
                    Auditoria.Add(auditoriaEntrada.MapAuditoria(NombreUsuarioActual));
                }
                catch (Exception){ }
            }

            return SaveChangesAsync();
        }
        private void ConfigurarEntidades(ModelBuilder builder)
        {
            builder.AddQueryFilter<IBaseModel>(e => !e.EsEliminado);
            builder.AddQueryFilter<IBaseCompania>(e => ObtenerCompaniaId() != null 
                                                        ? e.CompaniaId.Equals(ObtenerCompaniaId()) 
                                                        : !e.CompaniaId.Equals(Guid.Empty));

            var entidades = builder.Model.GetEntityTypes();
            
            var entidadesForeignKey = entidades
                .SelectMany(e => e.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            
            var entidadesPropiedadDecimal = entidades
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?));

            foreach (var entidad in entidades)
            {
                entidad.SetTableName(entidad.DisplayName());
            }

            foreach (var propiedad in entidadesPropiedadDecimal)
            {
                propiedad.SetColumnType("money");
            }

            foreach (var foreignKey in entidadesForeignKey)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        private void ActualizarEntidades()
        {
            var fechaActual = DateTime.Now.ObtenerFechaPeru();
            var entidadaEntradas = ChangeTracker.Entries().Where(e => e.Entity is IBaseModel);
            
            foreach (var entidadEntrada in entidadaEntradas)
            {
                if (!(entidadEntrada.Entity is IBaseModel entidad)) continue;
                switch (entidadEntrada.State)
                {
                    case EntityState.Added:
                        entidad.FechaCrea = fechaActual;
                        entidad.UsuarioCrea = NombreUsuarioActual;
                        entidad.EsEliminado = false;

                        if (entidad is IBaseCompania entidadCompania)
                            entidadCompania.CompaniaId = entidadCompania.CompaniaId.Equals(Guid.Empty) 
                                                            ? (Guid)ObtenerCompaniaId()
                                                            : entidadCompania.CompaniaId;

                        if (entidad is BaseModel<Guid> entidadIdGuid)
                            entidadIdGuid.Id = Guid.NewGuid();

                        break;
                    case EntityState.Modified:

                        entidad.FechaEdita = fechaActual;
                        entidad.UsuarioEdita = NombreUsuarioActual;

                        if (entidad is IBaseCompania entidadCompaniaMod)
                            entidadEntrada.Property(nameof(entidadCompaniaMod.CompaniaId)).IsModified = false;
                        
                        entidadEntrada.Property(nameof(entidad.FechaCrea)).IsModified = false;
                        entidadEntrada.Property(nameof(entidad.UsuarioCrea)).IsModified = false;

                        break;
                    case EntityState.Deleted:
                        
                        entidad.FechaEdita = fechaActual;
                        entidad.UsuarioEdita = NombreUsuarioActual;
                        entidad.EsEliminado = true;

                        entidadEntrada.Property(nameof(entidad.FechaCrea)).IsModified = false;
                        entidadEntrada.Property(nameof(entidad.UsuarioCrea)).IsModified = false;                       
                        if (entidad is IBaseCompania entidadCompaniaEli)
                            entidadEntrada.Property(nameof(entidadCompaniaEli.CompaniaId)).IsModified = false;

                        entidadEntrada.State = EntityState.Modified;
                        
                        break;
                }
            }
        }
        private Guid? ObtenerCompaniaId()
        {
            string? compania = null;

            if (_httpContextAccessor.HttpContext != null)
            {
                var claimsPrincipal = _httpContextAccessor.HttpContext.User;
                compania = claimsPrincipal.FindFirst(Claims.Compania)?.Value?.Desencriptar();
            }

            return compania is null? null : new Guid(compania);
        }
        private string ObtenerNombreUsuarioActual()
        {
            string currentUsername = string.Empty;

            if (_httpContextAccessor.HttpContext != null)
            {
                var claimsPrincipal = _httpContextAccessor.HttpContext.User;
                currentUsername = claimsPrincipal.FindFirst(Claims.NombreUsuario)?.Value?.Desencriptar() ?? "sistema";
            }

            return currentUsername;
        }
    }
}
