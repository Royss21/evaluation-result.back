
namespace Application.Main.Pagination
{
    public class ExpressionOrderBy<TDto, TProperty> : IExpressionOrderBy
    {
        private readonly Expression<Func<TDto, TProperty>> _sort;

        public ExpressionOrderBy(Expression<Func<TDto, TProperty>> sort)
        {
            _sort = sort;
        }

        public LambdaExpression GetLambdaExpression<TEntity>(IMapper mapper)
        {
            return mapper.MapExpression<Expression<Func<TEntity, TProperty>>>(_sort);
        }
    }

    public interface IExpressionOrderBy
    {
        LambdaExpression GetLambdaExpression<TEntity>(IMapper mapper);
    }
}