using SharedKernell.Enum;

namespace Application.Dto.Pagination
{
    public class PagingFilterDto
    {
        public int Start { get; set; } = 1;
        public int Rows { get; set; } = 10;
        public string? OrderColumn { get; set; } = "CreateDate";
        public int? SortType { get; set; } = (int)SortTypeEnum.Desc;
        public Dictionary<string, PrimeFilter>? Filters { get; set; }
        public string? GlobalFilter { get; set; } = string.Empty;
    }

    public class PrimeFilter
    {
        public string Value { get; set; } = string.Empty;
        public string MatchMode { get; set; } = string.Empty;
    }
}
