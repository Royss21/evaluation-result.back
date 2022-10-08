
namespace Application.Dto.Pagination
{
    using System.Collections.Generic;
    public class PaginationResultDto<T> where T : class
    {
        public int Count { get; set; }
        public IEnumerable<T> Entities { get; set; }
    }
}