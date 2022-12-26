using Application.Dto.Pagination;

namespace Application.Dto.EvaResult.ComponentCollaborator
{
    public class ComponentCollaboratorFilterDto : PagingFilterDto
    {
        public Guid EvaluationId { get; set; }
        public int ComponentId { get; set; }
    }
}
