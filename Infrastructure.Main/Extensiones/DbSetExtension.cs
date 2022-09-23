

namespace Infrastructure.Main.Extensiones
{

    using Dapper;
    using Microsoft.EntityFrameworkCore.Query;
    using System.Data;

    public static class DbSetExtension
    {
        public static async Task<IEnumerable<T>> FromSqlQueryAsync<T>(this DbContext dbContext, string sqlQuery,
            object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var commandType = CommandType.StoredProcedure;
            var connection = dbContext.Database.GetDbConnection();
            return await connection.QueryAsync<T>(sqlQuery, parameters, transaction, commandTimeout, commandType);
        }

        public static async Task<string> StringResultProcedure(this DbContext dbContext, string sqlQuery,
            object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var commandType = CommandType.StoredProcedure;
            var connection = dbContext.Database.GetDbConnection();

            return await connection.QueryFirstAsync<string>(sqlQuery, parameters, transaction, commandTimeout,
                commandType);
        }

        public static async Task ExecuteNonQueryAsync(this DbContext dbContext, string sqlQuery,
            object parameters = null, IDbTransaction transaction = null, int? commandTimeout = null)
        {
            var connection = dbContext.Database.GetDbConnection();

            await connection.ExecuteAsync(sqlQuery, parameters, transaction, commandTimeout, CommandType.Text);
        }

        public static void AddQueryFilter<T>(this ModelBuilder modelBuilder, Expression<Func<T, bool>> expression)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (!typeof(T).IsAssignableFrom(entityType.ClrType))
                    continue;

                var parameterType = Expression.Parameter(entityType.ClrType);
                var expressionFilter = ReplacingExpressionVisitor.Replace(
                    expression.Parameters.Single(), parameterType, expression.Body);

                var currentQueryFilter = entityType.GetQueryFilter();
                if (currentQueryFilter != null)
                {
                    var currentExpressionFilter = ReplacingExpressionVisitor.Replace(
                        currentQueryFilter.Parameters.Single(), parameterType, currentQueryFilter.Body);
                    expressionFilter = Expression.AndAlso(currentExpressionFilter, expressionFilter);
                }

                var lambdaExpression = Expression.Lambda(expressionFilter, parameterType);
                entityType.SetQueryFilter(lambdaExpression);
            }

        }
    }
}