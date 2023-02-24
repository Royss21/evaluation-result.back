
namespace Application.Dto.Report
{
    using Application.Dto.Pagination;
    public class EvaluationCollaboratorFinalResultFilterDto : PagingFilterDto
    {
        public Guid? EvaluationId { get; set; }
    }
}
