namespace Application.Main.PrimeNg.Operadores
{
    public class GreaterThanOrEqualOperator : IOperator
    {
        public Expression GenerateCompareExpression<T>(ParameterExpression parameterExpression, string itemField,
            Expression expressionValue)
            where T : class
        {
            return Expression.GreaterThanOrEqual(
                TreeExpressionHelper.GetLambdaMemberAccess<T>(parameterExpression, itemField), expressionValue);
        }
    }
}