namespace Infrastructure.Main.Context
{
    using Domain.Main.Base;
    using Domain.Common.Constants;
    using Microsoft.AspNetCore.Http;
    using Infrastructure.Main.Context.Configuration.Config;
    using Infrastructure.Main.Context.Configuration.Security;
    using Infrastructure.Main.Context.Configuration.EvaResult;
    using Infrastructure.Main.Context.Configuration.Collaborator;

    public class DbContextMain : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private string CurrentUserName { get; set; } = string.Empty;

        public DbContextMain(
            DbContextOptions<DbContextMain> options,
            Microsoft.AspNetCore.Http.IHttpContextAccessor httpContextAccessor
        ): base(options)
        {
            _httpContextAccessor = httpContextAccessor;
            CurrentUserName = GetCurrentUserName();
        }

        public DbSet<AuditEntity> AuditEntity { get; set; }
        public DbSet<Menu> Menu { get; set; } public DbSet<Role> Role { get; set; }
        public DbSet<RoleMenu> RoleMenu { get; set; }
        public DbSet<UserEndpointLocked> UserEndpointLocked { get; set; }
        public DbSet<Endpoint> Endpoint { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserToken> UserToken { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        #region Collaborator
        public DbSet<Area> Area { get; set; }
        public DbSet<Charge> Charge { get; set; }
        public DbSet<Gerency> Gerency { get; set; }
        public DbSet<Hierarchy> Hierarchy { get; set; }
        #endregion

        #region Config
        public DbSet<Component> Component { get; set; }
        public DbSet<Conduct> Conduct { get; set; }
        public DbSet<HierarchyComponent> HierarchyComponent { get; set; }
        public DbSet<Label> Label { get; set; }
        public DbSet<LabelDetail> LabelDetail { get; set; }
        public DbSet<Level> Level { get; set; }
        public DbSet<Stage> Stage { get; set; }
        public DbSet<Subcomponent> Subcomponent { get; set; }
        public DbSet<SubcomponentValue> SubcomponentValue { get; set; }
        #endregion


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .ApplyConfiguration(new AuditConfig())
                .ApplyConfiguration(new RoleConfig())
                .ApplyConfiguration(new RoleMenuConfig())
                .ApplyConfiguration(new UserEnpointLockedConfig())
                .ApplyConfiguration(new EndpointConfig())
                .ApplyConfiguration(new UserConfig())
                .ApplyConfiguration(new UserTokenConfig())
                .ApplyConfiguration(new UserRoleConfig())

                .ApplyConfiguration(new AreaConfig())
                .ApplyConfiguration(new ChargeConfig())
                .ApplyConfiguration(new GerencyConfig())
                .ApplyConfiguration(new HierarchyConfig())
                .ApplyConfiguration(new ComponentConfig())
                .ApplyConfiguration(new ConductConfig())
                .ApplyConfiguration(new HierarchyComponentConfig())
                .ApplyConfiguration(new LabelConfig())
                .ApplyConfiguration(new LabelDetailConfig())
                .ApplyConfiguration(new LevelConfig())
                .ApplyConfiguration(new StageConfig())
                .ApplyConfiguration(new SubcomponentConfig())
                .ApplyConfiguration(new SubcomponentValueConfig())

                .ApplyConfiguration(new ComponentCollaboratorConfig())
                .ApplyConfiguration(new ComponentCollaboratorDetailsConfig())
                .ApplyConfiguration(new ComponentCollaboratorStagesConfig())
                .ApplyConfiguration(new ComponentStagesConfig())
                .ApplyConfiguration(new EvaluationCollaboratorConfig())
                .ApplyConfiguration(new EvaluationComponentConfig())
                .ApplyConfiguration(new EvaluationConfig())
                .ApplyConfiguration(new EvaluationLeaderConfig())
                .ApplyConfiguration(new EvaluationStagesConfig())
                .ApplyConfiguration(new LeaderCollaboratorConfig())
                .ApplyConfiguration(new LeaderStageConfig())
                .ApplyConfiguration(new PeriodConfig());

            ConfigEntities(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
           CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateEntities();
            var auditEntries = AuditBeforeSaveChanges();
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            await AuditAfterSaveChanges(auditEntries);
            return result;
        }

        private List<AuditEntry> AuditBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();

            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is AuditEntity 
                     /*entry.Entity is LogSessionUser ||*/ 
                    || entry.State == EntityState.Detached 
                    || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditEntry(entry)
                {
                    TableName = entry.Metadata.GetTableName()
                };

                auditEntries.Add(auditEntry);

                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary)
                    {
                        auditEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    var propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue ?? "";
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.NewValues[propertyName] = property.CurrentValue ?? "";
                            break;

                        case EntityState.Deleted:
                            auditEntry.OldValues[propertyName] = property.OriginalValue ?? "";
                            break;

                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.OldValues[propertyName] = property.OriginalValue ?? "";
                                auditEntry.NewValues[propertyName] = property.CurrentValue ?? "";
                            }

                            break;
                    }
                }
            }
            auditEntries.ForEach(ae =>
            {
                try
                {
                    if (!ae.HasTemporaryProperties)
                        AuditEntity.Add(ae.MapAudit(CurrentUserName));
                }
                catch (Exception) { }

            });

            return auditEntries.Where(entry => entry.HasTemporaryProperties).ToList();
        }
        private Task AuditAfterSaveChanges(List<AuditEntry> auditEntries)
        {
            if (auditEntries is null || !auditEntries.Any())
                return Task.CompletedTask;

            foreach (var auditEntry in auditEntries)
            {
                foreach (var prop in auditEntry.TemporaryProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                        auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue ?? "";
                    else
                        auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue ?? "";
                }

                try
                {
                    AuditEntity.Add(auditEntry.MapAudit(CurrentUserName));
                }
                catch (Exception){ }
            }

            return SaveChangesAsync();
        }
        private void ConfigEntities(ModelBuilder builder)
        {
            builder.AddQueryFilter<IBaseModel>(e => !e.IsDeleted);

            var entityTypes = builder.Model.GetEntityTypes();
            
            var entidadesForeignKey = entityTypes
                .SelectMany(e => e.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            
            var mutableProperties = entityTypes
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?));

            foreach (var entityType in entityTypes)
            {
                entityType.SetTableName(entityType.DisplayName());
            }

            foreach (var property in mutableProperties)
            {
                property.SetColumnType("money");
            }

            foreach (var foreignKey in entidadesForeignKey)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        private void UpdateEntities()
        {
            var currentDate = DateTime.Now.GetDatePeru();
            var entityEntries = ChangeTracker.Entries().Where(e => e.Entity is IBaseModel);
            
            foreach (var entityEntry in entityEntries)
            {
                if (!(entityEntry.Entity is IBaseModel entity)) continue;
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        entity.CreateDate = currentDate;
                        entity.CreateUser = CurrentUserName;
                        entity.IsDeleted = false;

                        if (entity is BaseModel<Guid> entityGuidId)
                            entityGuidId.Id = Guid.NewGuid();

                        break;
                    case EntityState.Modified:

                        entity.EditDate = currentDate;
                        entity.EditUser = CurrentUserName;

                        entityEntry.Property(nameof(entity.CreateDate)).IsModified = false;
                        entityEntry.Property(nameof(entity.CreateUser)).IsModified = false;

                        break;
                    case EntityState.Deleted:

                        entity.EditDate = currentDate;
                        entity.EditUser = CurrentUserName;
                        entity.IsDeleted = true;

                        entityEntry.Property(nameof(entity.CreateDate)).IsModified = false;
                        entityEntry.Property(nameof(entity.CreateUser)).IsModified = false;

                        entityEntry.State = EntityState.Modified;
                        
                        break;
                }
            }
        }
        private string GetCurrentUserName()
        {
            string currentUsername = string.Empty;

            if (_httpContextAccessor.HttpContext != null)
            {
                var claimsPrincipal = _httpContextAccessor.HttpContext.User;
                currentUsername = claimsPrincipal.FindFirst(Claims.userName)?.Value?.Decrypt() ?? "system";
            }

            return currentUsername;
        }
    }
}
