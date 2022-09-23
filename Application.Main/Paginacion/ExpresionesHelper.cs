

namespace Application.Main.Paginacion
{
    public static class ExpresionesHelper
    {
        public static ParametrosPaginacion<TEntity> ConvertToPaginationParameterDomain<TEntity, TDto>(
            this PaginacionParametrosDto<TDto> parameters, IMapper mapper)
            where TEntity : class
            where TDto : class
        {
            var expressionEntity = mapper.MapExpression<Expression<Func<TEntity, bool>>>(parameters.FiltroWhere);

            IExpresionOrdernarPor orderByLambda = null;

            if (!string.IsNullOrWhiteSpace(parameters.ColumnaOrden))
            {
                var pascalCaseField = StringHelper.APascalCase(parameters.ColumnaOrden);
                PropertyInfo propertyDtoOrderBy = typeof(TDto).GetProperty(pascalCaseField);
                var typeArguments = new[] { typeof(TDto), propertyDtoOrderBy.PropertyType };

                Type type = typeof(ExpresionOrdernarPor<,>).MakeGenericType(typeArguments);

                orderByLambda = (IExpresionOrdernarPor)Activator.CreateInstance(type,
                    TreeExpressionHelper.ObtenerAccesoMiembroLambda<TDto>(pascalCaseField)); 
            }

            var paginationParameters = new ParametrosPaginacion<TEntity>
            {
                ColumnaOrden = orderByLambda?.GetLambdaExpression<TEntity>(mapper),
                CantidadFilas = parameters.CantidadFilas,
                Empieza = parameters.Empieza,
                TipoOrden = parameters.TipoOrden,
                FiltroWhere = expressionEntity
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