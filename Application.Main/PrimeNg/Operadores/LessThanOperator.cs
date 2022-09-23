namespace Application.Main.PrimeNg.Operadores
{
    public class LessThanOperator : IOperator
    {
        public Expression GenerateCompareExpression<T>(ParameterExpression parameterExpression, string itemField,
            Expression expressionValue)
            where T : class
        {
            return Expression.LessThan(
                TreeExpressionHelper.ObtenerAccesoMiembroLambda<T>(parameterExpression, itemField), expressionValue);
        }
    }
}