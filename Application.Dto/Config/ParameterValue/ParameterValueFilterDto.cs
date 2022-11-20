
namespace Application.Dto.Config.ParameterValue
{
    using Application.Dto.Pagination;
    public class ParameterValueFilterDto : PagingFilterDto
    {
        public Guid ParameterRangeId { get; set; } = Guid.Empty;
    }
}
