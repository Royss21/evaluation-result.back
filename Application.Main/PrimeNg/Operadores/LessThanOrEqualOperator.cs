namespace Application.Main.PrimeNg.Operadores
{
    public class LessThanOrEqualOperator : IOperator
    {
        public Expression GenerateCompareExpression<T>(ParameterExpression parameterExpression, string itemField,
            Expression expressionValue)
            where T : class
        {
            return Expression.LessThanOrEqual(
                TreeExpressionHelper.ObtenerAccesoMiembroLambda<T>(parameterExpression, itemField), expressionValue);
        }
    }
}