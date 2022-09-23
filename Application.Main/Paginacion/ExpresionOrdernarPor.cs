
namespace Application.Main.Paginacion
{
    public class ExpresionOrdernarPor<TDto, TProperty> : IExpresionOrdernarPor
    {
        private readonly Expression<Func<TDto, TProperty>> _sort;

        public ExpresionOrdernarPor(Expression<Func<TDto, TProperty>> sort)
        {
            _sort = sort;
        }

        public LambdaExpression GetLambdaExpression<TEntity>(IMapper mapper)
        {
            return mapper.MapExpression<Expression<Func<TEntity, TProperty>>>(_sort);
        }
    }

    public interface IExpresionOrdernarPor
    {
        LambdaExpression GetLambdaExpression<TEntity>(IMapper mapper);
    }
}