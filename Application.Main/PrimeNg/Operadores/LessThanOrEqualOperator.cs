namespace Application.Main.PrimeNg.Operadores
{
    public class LessThanOrEqualOperator : IOperator
    {
        public Expression GenerateCompareExpression<T>(ParameterExpression parameterExpression, string itemField,
            Expression expressionValue)
            where T : class
        {
            return Expression.LessThanOrEqual(
                TreeExpressionHelper.GetLambdaMemberAccess<T>(parameterExpression, itemField), expressionValue);
        }
    }
}