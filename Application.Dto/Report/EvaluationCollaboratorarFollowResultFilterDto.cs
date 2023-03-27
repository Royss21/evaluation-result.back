
namespace Application.Dto.Report
{
    using Application.Dto.Pagination;
    using System.Text.Json.Serialization;

    public class EvaluationCollaboratorarFollowResultFilterDto : PagingFilterDto
    {
        public Guid? EvaluationId { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
