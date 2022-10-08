
namespace Application.Main.Pagination
{
    public class PaginationParametersDto<T> where T : class
    {
        public string OrderColumn { get; set; }
        public SortTypeEnum SortType { get; set; }
        public int Start { get; set; }
        public int RowsCount { get; set; }
        public Expression<Func<T, bool>> FilterWhere { get; set; }
    }
}