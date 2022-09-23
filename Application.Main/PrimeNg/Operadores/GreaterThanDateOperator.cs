namespace Application.Main.PrimeNg.Operadores
{
    public class GreaterThanDateOperator : IOperator
    {
        public Expression GenerateCompareExpression<T>(ParameterExpression parameterExpression, string itemField,
            Expression expressionValue)
            where T : class
        {
            var expressionMember = TreeExpressionHelper.ObtenerAccesoMiembroLambda<T>(parameterExpression, itemField);

            if (expressionMember.Type == typeof(DateTime?))
            {
                expressionMember = Expression.Property(expressionMember, "Value");
                expressionMember = Expression.Property(expressionMember, "Date");
            }

            return Expression.GreaterThan(expressionMember, expressionValue);
        }
    }
}