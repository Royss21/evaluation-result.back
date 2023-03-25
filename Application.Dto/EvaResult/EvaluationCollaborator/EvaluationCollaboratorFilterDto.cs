
namespace Application.Dto.EvaResult.EvaluationCollaborator
{
    using Application.Dto.Pagination;
    public class EvaluationCollaboratorFilterDto : PagingFilterDto
    {
        public Guid EvaluationId { get; set; }
    }
}
