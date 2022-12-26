namespace Application.Main.PrimeNg.Operadores
{
    public class LessThanDateOperator : IOperator
    {
        public Expression GenerateCompareExpression<T>(ParameterExpression parameterExpression, string itemField,
            Expression expressionValue)
            where T : class
        {
            var expressionMember = TreeExpressionHelper.GetLambdaMemberAccess<T>(parameterExpression, itemField);

            if (expressionMember.Type == typeof(DateTime?))
            {
                expressionMember = Expression.Property(expressionMember, "Value");
                expressionMember = Expression.Property(expressionMember, "Date");
            }

            return Expression.LessThan(expressionMember, expressionValue);
        }
    }
}