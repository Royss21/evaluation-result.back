

namespace Application.Main.PrimeNg.Helpers
{
    using SharedKernell.Constants;
    public static class LambdaManager
    {
        public static Expression<Func<T, bool>> ConvertToLambda<T>(List<ColumnsFilter> filters) where T : class
        {
            var parameterExpression = Expression.Parameter(typeof(T), "p");
            Expression<Func<T, bool>> expresionsLambdaSet = ReadFilterColumns<T>(filters, parameterExpression);

            return expresionsLambdaSet ?? PredicateBuilder.New<T>(true);
        }

        private static readonly Dictionary<string, IOperator> Operators = new()
        {
            {FilterModMatchConst.Contains, new ContainsOperator()},
            {FilterModMatchConst.In, new ContainsOperator()},
            {FilterModMatchConst.Equals, new EqualOperator()},
            {FilterModMatchConst.NotEquals, new NotEqualOperator()},
            {FilterModMatchConst.GreaterThanOrEqualTo, new GreaterThanOrEqualOperator()},
            {FilterModMatchConst.LessThanOrEqualTo, new LessThanOrEqualOperator()},
            {FilterModMatchConst.GreaterThan, new GreaterThanOperator()},
            {FilterModMatchConst.LessThan, new LessThanOperator()},
            {FilterModMatchConst.EndsWith, new EndsWithOperator()},
            {FilterModMatchConst.StartsWith, new StartsWithOperator()},
            {FilterModMatchConst.DateIs, new EqualDateOperator()},
            {FilterModMatchConst.DateIsNot, new NotEqualDateOperator()},
            {FilterModMatchConst.DateBefore, new LessThanDateOperator()},
            {FilterModMatchConst.DateAfter, new GreaterThanDateOperator()},
            {FilterModMatchConst.NotContains, new NotContainsOperator()}
        };

        private static Expression<Func<T, bool>> ReadFilterColumns<T>(List<ColumnsFilter> filters,
            ParameterExpression parameterExpression) where T : class
        {
            Expression<Func<T, bool>> expresionsLambdaSet = null;

            foreach (var filter in filters)
            {
                var pascalCaseField = StringHelper.ToPascalCase(filter.Field);
                var fieldType = TreeExpressionHelper.ObtenerTipoPropiedad<T>(pascalCaseField);
                var constantExpression = GetConstantExpression(filter.Value, fieldType);

                var comparisonFilterExpression = Operators[filter.Operator]
                    .GenerateCompareExpression<T>(parameterExpression, pascalCaseField, constantExpression);

                var expressionLambdaFilter =
                    Expression.Lambda<Func<T, bool>>(comparisonFilterExpression, parameterExpression);

                expresionsLambdaSet = expresionsLambdaSet == null
                    ? expressionLambdaFilter
                    : expresionsLambdaSet.And(expressionLambdaFilter);
            }

            return expresionsLambdaSet;
        }

        private static ConstantExpression GetConstantExpression(string value, Type type)
        {
            if (type == typeof(string)) return Expression.Constant(value, type);

            var nullableType = Nullable.GetUnderlyingType(type);

            if (nullableType == typeof(DateTime)) type = nullableType;

            return Expression.Constant(Convert.ChangeType(value, nullableType ?? type), type);
        }
    }
}