

namespace Application.Dto.EvaResult.EvaluationLeader
{
    using Application.Dto.EvaResult.LeaderStage;
    public class EvaluationLeaderExistingDto : BaseEvaluationLeaderDto
    {
        public int Id { get; set; }
        public Guid CollaboratorId { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
        public List<LeaderStageExistingDto> LeaderStagesExistingDto { get; set; } = new List<LeaderStageExistingDto>();

    }

}
