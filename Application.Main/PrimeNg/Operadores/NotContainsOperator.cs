namespace Application.Main.PrimeNg.Operadores
{
    public class NotContainsOperator : IOperator
    {
        public Expression GenerateCompareExpression<T>(ParameterExpression parameterExpression, string itemField,
            Expression expressionValue)
            where T : class
        {
            return Expression.Not(
                new ContainsOperator().GenerateCompareExpression<T>(parameterExpression, itemField, expressionValue));
        }
    }
}