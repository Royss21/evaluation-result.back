
namespace Application.Dto.Security.Authentication
{
    public class AccessCollaboratorDto
    {
        public Guid EvaluationCollaboratorId { get; set; }
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public string ExpiredIn { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool IsLeaderCompetence { get; set; }
        public bool IsLeaderAreaObjetive { get; set; }
        public Guid EvaluationId { get; set; }
        public int TypeViewCollaborator { get; set; }
        //public List<MenuDto> Menus { get; set; }

    }
}
