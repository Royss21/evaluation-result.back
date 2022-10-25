
namespace Infrastructure.Data.MainModule.Repository
{
    public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
        where TEntity : class
        where TId : IComparable<TId>
    {
        protected DbContextMain _dbContextMain { get; }
        protected DbSet<TEntity> DbSet { get; set; }

        public BaseRepository(DbContextMain dbContextMain)
        {
            _dbContextMain = dbContextMain;
            DbSet = _dbContextMain.Set<TEntity>();
        }

        public BaseRepository(DbContextMain dbContextMain, DbSet<TEntity> dbSet)
        {
            _dbContextMain = dbContextMain;
            DbSet = dbSet;
        }


        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            _dbContextMain.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public virtual IQueryable<TEntity> All(bool @readonly = true)
        {
            return @readonly ? DbSet.AsNoTracking() : DbSet;
        }

        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await DbSet.Where(expression).CountAsync();
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = true)
        {
            IQueryable<TEntity> query = DbSet;

            if (@readonly)
                query = query.AsNoTracking();

            return query.Where(predicate);
        }

        public async Task<TEntity> GetAsync(TId id)
        {
            var keyProperty = _dbContextMain.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties[0];
            var keyId = (object) Convert.ChangeType(id, typeof(TId));
            var dbSet = (IQueryable<TEntity>) DbSet;

            return await dbSet.FirstOrDefaultAsync(x => EF.Property<object>(x, keyProperty.Name) == keyId);
        }

        public async Task<ValidationResult> AddAsync(TEntity entity, params IValidator<TEntity>[] validaciones)
        {
            var validateEntityResult = await ValidateEntityAsync(entity, validaciones);
            return await AddEntityAsync(entity, validateEntityResult);
        }

        public async Task<ValidationResult> AddAsync(TEntity entity, IValidator<TEntity> validation)
        {
            var validateEntityResult = await ValidateEntityAsync(entity, validation);

            return await AddEntityAsync(entity, validateEntityResult);
        }

        public async Task<ValidationResult> UpdateAsync(TEntity entity, params IValidator<TEntity>[] validaciones)
        {
            var validateEntityResult = await ValidateEntityAsync(entity, validaciones);

            if (validateEntityResult.IsValid) Update(entity);

            return validateEntityResult;
        }

        public async Task<ValidationResult> UpdateAsync(TEntity entity, IValidator<TEntity> validation)
        {
            var validateEntityResult = await ValidateEntityAsync(entity, validation);

            if (validateEntityResult.IsValid) Update(entity);

            return validateEntityResult;
        }

        public async Task<ValidationResult> DeleteAsync(TEntity entity, params IValidator<TEntity>[] validaciones)
        {
            var validateEntityResult = await ValidateEntityAsync(entity, validaciones);

            if (validateEntityResult.IsValid) _dbContextMain.Remove(entity);

            return validateEntityResult;
        }

        public async Task<ValidationResult> DeleteAsync(TEntity entity, IValidator<TEntity> validation)
        {
            var validateEntityResult = await ValidateEntityAsync(entity, validation);

            if (validateEntityResult.IsValid) _dbContextMain.Remove(entity);
            return validateEntityResult;
        }

        public async Task<ValidationResult> ValidateEntityAsync(TEntity entity, IValidator<TEntity> validation)
        {
            if (validation != null)
            {
                var validationResultEntity = await validation.ValidateAsync(entity);
                return validationResultEntity;
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> ValidateEntityAsync(TEntity entity,
            IEnumerable<IValidator<TEntity>> validations)
        {
            if (validations != null)
            {
                var errors = new List<ValidationFailure>();

                foreach (var validation in validations)
                {
                    var currentValidationResult = await validation.ValidateAsync(entity);

                    if (!currentValidationResult.IsValid)
                        errors.AddRange(currentValidationResult.Errors);
                }

                return new ValidationResult(errors);
            }

            return new ValidationResult();
        }

        public async Task<ValidationResult> AddEntityAsync(TEntity entity, ValidationResult validationResultEntity)
        {
            if (validationResultEntity.IsValid)
                //await DbSet.AddAsync(entity);
                await _dbContextMain.AddAsync(entity);

            return validationResultEntity;
        }

        public async Task<IEnumerable<TDto>> RunSqlQuery<TDto>(string sqlQuery, object parameters = null)
        {
            return await _dbContextMain.FromSqlQueryAsync<TDto>(sqlQuery, parameters);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities);
        }
        
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            DbSet.UpdateRange(entities);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        public async Task BulkDeleteAsync(IEnumerable<TEntity> entities, List<string> updateByProperties = null,
            bool preserveInsertOrder = false, bool setOutputIdentity = false)
        {
            BulkConfig bulkConfig = new BulkConfig
            {
                UpdateByProperties = updateByProperties, PreserveInsertOrder = preserveInsertOrder,
                SetOutputIdentity = setOutputIdentity
            };
            await _dbContextMain.BulkDeleteAsync(entities.ToList(), bulkConfig);
        }

        public async Task BulkInsertAsync(IEnumerable<TEntity> entities, List<string> updateByProperties = null,
            bool preserveInsertOrder = false, bool setOutputIdentity = false)
        {
            BulkConfig bulkConfig = new BulkConfig
            {
                UpdateByProperties = updateByProperties, PreserveInsertOrder = preserveInsertOrder,
                SetOutputIdentity = setOutputIdentity
            };
            await _dbContextMain.BulkInsertAsync(entities.ToList(), bulkConfig);
        }

        public async Task BulkInsertOrUpdateAsync(IEnumerable<TEntity> entities, List<string> updateByProperties = null,
            bool preserveInsertOrder = false, bool setOutputIdentity = false)
        {
            BulkConfig bulkConfig = new BulkConfig
            {
                UpdateByProperties = updateByProperties, PreserveInsertOrder = preserveInsertOrder,
                SetOutputIdentity = setOutputIdentity
            };
            await _dbContextMain.BulkInsertOrUpdateAsync(entities.ToList(), bulkConfig);
        }

        public async Task BulkInsertOrUpdateOrDeleteAsync(IEnumerable<TEntity> entities,
            List<string> updateByProperties = null, bool preserveInsertOrder = false, bool setOutputIdentity = false)
        {
            BulkConfig bulkConfig = new BulkConfig
            {
                UpdateByProperties = updateByProperties, PreserveInsertOrder = preserveInsertOrder,
                SetOutputIdentity = setOutputIdentity
            };
            await _dbContextMain.BulkInsertOrUpdateOrDeleteAsync(entities.ToList(), bulkConfig);
        }

        public virtual async Task<PaginationResult<TEntity>> FindAllPagingAsync(
            PaginationParameters<TEntity> parameters, bool @readonly = true)
        {
            var paging = GetDataWithFilter(parameters, @readonly);
            return await PagingAsync(parameters, paging);
        }

        public virtual void Update(TEntity entity)
        {
            if (DbSet.Local.All(p => p != entity))
            {
                DbSet.Attach(entity);
                var entry = _dbContextMain.Entry(entity);
                entry.State = EntityState.Modified;
            }
        }

        public void Delete(TEntity entity)
        {
            DbSet.Attach(entity);

            var entry = _dbContextMain.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        protected IQueryable<TEntity> GetDataWithFilter(PaginationParameters<TEntity> parameters, bool @readonly = true)
        {
            var dbSet = parameters.Include != null ? parameters.Include(DbSet) : (IQueryable<TEntity>) DbSet;
            return (@readonly ? dbSet.AsNoTracking() : dbSet).Where(parameters.FilterWhere ?? (f=> true));
        }

        protected async Task<PaginationResult<TNewEntity>> PagingAsync<TNewEntity>(
            PaginationParameters<TNewEntity> parameters, IQueryable<TNewEntity> pagingQuery) where TNewEntity : class
        {
            if (parameters.OrderColumn != null)
            {
                pagingQuery = parameters.SortType == SortTypeEnum.Asc
                    ? Queryable.OrderBy(pagingQuery, (dynamic) parameters.OrderColumn)
                    : Queryable.OrderByDescending(pagingQuery, (dynamic) parameters.OrderColumn);
            }

            return new PaginationResult<TNewEntity>
            {
                Count = await pagingQuery.CountAsync(),
                Entities = parameters.PaginationIgnore
                    ? pagingQuery
                    : pagingQuery.Skip((parameters.Start - 1)* parameters.RowsCount).Take(parameters.RowsCount)
            };
        }
    }
}