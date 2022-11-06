namespace Application.Dto.EvaResult.LeaderCollaborator
{
    public class LeaderCollaboratorExistingDto : BaseLeaderCollaboratorDto
    {
        public int Id { get; set; }
        public string DocumentNumber { get; set; } = string.Empty;
    }
}
