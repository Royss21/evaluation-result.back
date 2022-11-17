
namespace Application.Dto.Config.Subcomponent
{
    using Application.Dto.Pagination;
    public class SubcomponentFilterDto : PagingFilterDto
    {
        public int ComponentId { get; set; }

    }
}
