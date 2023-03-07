
namespace Application.Dto.EvaResult.EvaluationCollaborator
{
    using Application.Dto.Pagination;
    public class EvaluationCollaboratorReviewFilterDto : PagingFilterDto
    {
        public Guid? EvaluationCollaboratorId { get; set; } = null;
        public int StageId { get; set; }
        public Guid EvaluationId { get; set; }

    }
}
