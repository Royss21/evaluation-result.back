


namespace Application.Main.Pagination
{
    using SharedKernell.Pagination;
    public static class ExpressionHelpers
    {
        public static PaginationParameters<TEntity> ConvertToPaginationParameterDomain<TEntity, TDto>(
            this PaginationParametersDto<TDto> parameters, IMapper mapper)
            where TEntity : class
            where TDto : class
        {
            var expressionEntity = mapper.MapExpression<Expression<Func<TEntity, bool>>>(parameters.FilterWhere);

            IExpressionOrderBy orderByLambda = null;

            if (!string.IsNullOrWhiteSpace(parameters.OrderColumn))
            {
                var pascalCaseField = StringHelper.ToPascalCase(parameters.OrderColumn);
                PropertyInfo propertyDtoOrderBy = typeof(TDto).GetProperty(pascalCaseField);
                var typeArguments = new[] { typeof(TDto), propertyDtoOrderBy.PropertyType };

                Type type = typeof(ExpressionOrderBy<,>).MakeGenericType(typeArguments);

                orderByLambda = (IExpressionOrderBy)Activator.CreateInstance(type,
                    TreeExpressionHelper.GetLambdaMemberAccess<TDto>(pascalCaseField)); 
            }

            var paginationParameters = new PaginationParameters<TEntity>
            {
                OrderColumn = orderByLambda?.GetLambdaExpression<TEntity>(mapper),
                RowsCount = parameters.RowsCount,
                Start = parameters.Start,
                SortType = parameters.TypeOrder,
                FilterWhere = expressionEntity
            };

            return paginationParameters;
        }

        public static Expression<Func<TEntity, bool>> AddCondition<TEntity>(this Expression<Func<TEntity, bool>> predicate, 
                                                                            Expression<Func<TEntity, bool>> newRestriction)
        {
            if (predicate == null)
                return PredicateBuilder.New<TEntity>().And(newRestriction);

            return predicate.And(newRestriction);
        }
    }
}