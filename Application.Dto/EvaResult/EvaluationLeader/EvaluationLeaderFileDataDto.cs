
namespace Application.Dto.EvaResult.EvaluationLeader
{
    public class EvaluationLeaderFileDataDto
    {
        public int? StageId { get; set; }
        public int? AreaId { get; set; }
        public string StageName { get; set; } = string.Empty;
        public string DniLeader { get; set; } = string.Empty;
        public string LeaderName { get; set; } = string.Empty;
        public string DniCollaborator { get; set; } = string.Empty;
        public string CollaboratorName { get; set; } = string.Empty;
    }
}
