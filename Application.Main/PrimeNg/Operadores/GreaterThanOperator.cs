namespace Application.Main.PrimeNg.Operadores
{
    public class GreaterThanOperator : IOperator
    {
        public Expression GenerateCompareExpression<T>(ParameterExpression parameterExpression, string itemField,
            Expression expressionValue)
            where T : class
        {
            return Expression.GreaterThan(
                TreeExpressionHelper.ObtenerAccesoMiembroLambda<T>(parameterExpression, itemField), expressionValue);
        }
    }
}