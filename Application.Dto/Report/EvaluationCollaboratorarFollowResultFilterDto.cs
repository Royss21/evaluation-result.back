
namespace Application.Dto.Report
{
    using Application.Dto.Pagination;
    public class EvaluationCollaboratorarFollowResultFilterDto : PagingFilterDto
    {
        public Guid? EvaluationId { get; set; }
    }
}
