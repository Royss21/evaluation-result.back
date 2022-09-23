
namespace Application.Main.PrimeNg.Operadores
{
    public class EndsWithOperator : IOperator
    {
        public Expression GenerateCompareExpression<T>(ParameterExpression parameterExpression, string itemField,
            Expression expressionValue)
            where T : class
        {
            var endsWithMethod = typeof(string).GetMethod("EndsWith", new[] {typeof(string)});

            return Expression.Call(TreeExpressionHelper.ObtenerAccesoMiembroLambda<T>(parameterExpression, itemField),
                endsWithMethod, expressionValue);
        }
    }
}