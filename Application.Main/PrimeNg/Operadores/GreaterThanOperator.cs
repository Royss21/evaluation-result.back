namespace Application.Main.PrimeNg.Operadores
{
    public class GreaterThanOperator : IOperator
    {
        public Expression GenerateCompareExpression<T>(ParameterExpression parameterExpression, string itemField,
            Expression expressionValue)
            where T : class
        {
            return Expression.GreaterThan(
                TreeExpressionHelper.GetLambdaMemberAccess<T>(parameterExpression, itemField), expressionValue);
        }
    }
}