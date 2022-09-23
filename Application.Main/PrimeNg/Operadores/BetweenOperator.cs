
namespace Application.Main.PrimeNg.Operadores
{
    public class BetweenOperator : IOperator
    {
        public Expression GenerateCompareExpression<T>(ParameterExpression parameterExpression, string itemField,
            Expression expressionValue)
            where T : class
        {
            var left = new GreaterThanOrEqualOperator().GenerateCompareExpression<T>(parameterExpression, itemField,
                expressionValue);
            var right = new LessThanOrEqualOperator().GenerateCompareExpression<T>(parameterExpression, itemField,
                expressionValue);

            return Expression.AndAlso(left, right);
        }
    }
}