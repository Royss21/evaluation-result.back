namespace Application.Main.PrimeNg.Operadores
{
    public class EqualOperator : IOperator
    {
        public Expression GenerateCompareExpression<T>(ParameterExpression parameterExpression, string itemField,
            Expression expressionValue)
            where T : class
        {
            return Expression.Equal(TreeExpressionHelper.ObtenerAccesoMiembroLambda<T>(parameterExpression, itemField),
                expressionValue);
        }
    }
}