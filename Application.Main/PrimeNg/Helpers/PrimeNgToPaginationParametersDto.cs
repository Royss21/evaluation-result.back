


namespace Application.Main.PrimeNg.Helpers
{
    using Application.Dto.Pagination;
    using Application.Main.Pagination;
    public class PrimeNgToPaginationParametersDto<TDto> where TDto : class
    {
        public static PaginationParametersDto<TDto> Convert(PagingFilterDto primeTable)
        {
            var filter = new List<ColumnsFilter>();

            if (primeTable.Filters != null)
            {
                filter = primeTable.Filters
                    .Where(p => !string.IsNullOrWhiteSpace(p.Value.Value) && p.Key != "global")
                    .Select(p => new ColumnsFilter
                    {
                        Field = p.Key,
                        Value = p.Value.Value.Trim(),
                        Operator = p.Value.MatchMode
                    }).ToList();
            }

            var filterParameterDto = new PaginationParametersDto<TDto>
            {
                Start = primeTable.Start,
                RowsCount = primeTable.Rows,
                OrderColumn = primeTable.OrderColumn,
                TypeOrder = (SortTypeEnum)primeTable.typeOrder,
                FilterWhere = filter.Any() ? LambdaManager.ConvertToLambda<TDto>(filter) : null
            };

            return filterParameterDto;
        }
    }
}