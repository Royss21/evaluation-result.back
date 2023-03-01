
namespace Application.Dto.Report
{
    using Application.Dto.Pagination;
    using System.Text.Json.Serialization;

    public class EvaluationCollaboratorFinalResultFilterDto : PagingFilterDto
    {
        public Guid? EvaluationId { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
