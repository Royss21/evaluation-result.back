using System.Text.Json.Serialization;

namespace Application.Dto.EvaResult.EvaluationLeader
{
    public class LeaderEvaluateComponentDto
    {
        public Guid EvaluationId { get; set; }
        public string EvaluationComponentsId { get; set; }
    }
}
