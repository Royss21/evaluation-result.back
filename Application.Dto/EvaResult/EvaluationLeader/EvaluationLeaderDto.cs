using System.Text.Json.Serialization;

namespace Application.Dto.EvaResult.EvaluationLeader
{
    public class EvaluationLeaderDto : BaseEvaluationLeaderDto
    {
        public int Id { get; set; }

        public string DocumentNumber { get; set; } = string.Empty;
        public string LeaderName { get; set; } = string.Empty;
        public int CountAssignedCollaborator { get; set; }


        [JsonIgnore]
        public List<int> StagesId { get; set; } = new List<int>(); 
        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
