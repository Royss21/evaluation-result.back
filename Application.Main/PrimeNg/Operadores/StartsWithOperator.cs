namespace Application.Main.PrimeNg.Operadores
{
    public class StartsWithOperator : IOperator
    {
        public Expression GenerateCompareExpression<T>(ParameterExpression parameterExpression, string itemField,
            Expression expressionValue)
            where T : class
        {
            var startsWithMethod = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });

            return Expression.Call(TreeExpressionHelper.GetLambdaMemberAccess<T>(parameterExpression, itemField),
                startsWithMethod, expressionValue);
        }
    }
}