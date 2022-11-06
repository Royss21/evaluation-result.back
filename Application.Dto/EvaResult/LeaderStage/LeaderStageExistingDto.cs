
namespace Application.Dto.EvaResult.LeaderStage
{
    using Application.Dto.EvaResult.LeaderCollaborator;
    public class LeaderStageExistingDto : BaseLeaderStageDto
    {
        public int Id { get; set; }
        public List<LeaderCollaboratorExistingDto> LeaderCollaboratorsExistingDto { get; set; } = new List<LeaderCollaboratorExistingDto>();
    }
}
