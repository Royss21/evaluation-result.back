
namespace Application.Dto.EvaResult.EvaluationLeader
{
    public class EvaluationLeaderFileDataDto
    {
        public int? StageId { get; set; }
        public string NameStage { get; set; } = string.Empty;
        public string DniLeader { get; set; } = string.Empty;
        public string NameLeader { get; set; } = string.Empty;
        public string DniCollaborator { get; set; } = string.Empty;
        public string NameCollaborator { get; set; } = string.Empty;
    }
}
