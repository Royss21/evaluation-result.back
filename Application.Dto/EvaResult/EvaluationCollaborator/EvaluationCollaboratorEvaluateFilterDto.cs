
namespace Application.Dto.EvaResult.EvaluationCollaborator
{
    using Application.Dto.Pagination;
    public class EvaluationCollaboratorEvaluateFilterDto : PagingFilterDto
    {
        public Guid EvaluationId { get; set; }
        public int ComponentId { get; set; }
    }
}
