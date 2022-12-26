namespace Application.Main.PrimeNg.Operadores
{
    public class NotEqualOperator : IOperator
    {
        public Expression GenerateCompareExpression<T>(ParameterExpression parameterExpression, string itemField,
            Expression expressionValue)
            where T : class
        {
            return Expression.NotEqual(TreeExpressionHelper.GetLambdaMemberAccess<T>(parameterExpression, itemField),
                expressionValue);
        }
    }
}