using System.Collections.Generic;

namespace Application.Main.PrimeNg
{
    public class PrimeTable
    {
        public int Start { get; set; } = 1;
        public int Rows { get; set; } = 10;
        public string? OrderColumn { get; set; }= "CreateDate";
        public int? SortType { get; set; } = (int)SortTypeEnum.Desc;
        public Dictionary<string, PrimeFilter>? Filters { get; set; }
        public string? GlobalFilter { get; set; } = string.Empty;
    }
}