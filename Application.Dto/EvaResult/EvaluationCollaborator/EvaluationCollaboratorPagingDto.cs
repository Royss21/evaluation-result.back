
namespace Application.Dto.EvaResult.EvaluationCollaborator
{
    using System.Text.Json.Serialization;
    public class EvaluationCollaboratorPagingDto : BaseEvaluationCollaboratorDto
    {
        public Guid Id { get; set; }
        public string CollaboratorName { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public string HierarchyName { get; set; } = string.Empty;
        public string ChargeName { get; set; } = string.Empty;
        public string AreaName { get; set; } = string.Empty;
        public string GerencyName { get; set; } = string.Empty;


        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
