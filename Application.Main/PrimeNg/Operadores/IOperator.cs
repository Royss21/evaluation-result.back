namespace Application.Main.PrimeNg.Operadores
{
    public interface IOperator
    {
        Expression GenerateCompareExpression<T>(ParameterExpression parameterExpression, string itemField,
            Expression expressionValue)
            where T : class;
    }
}