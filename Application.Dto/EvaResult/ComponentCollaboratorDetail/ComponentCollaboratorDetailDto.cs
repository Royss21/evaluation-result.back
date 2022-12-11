using Application.Dto.EvaResult.ComponentCollaboratorConduct;

namespace Application.Dto.EvaResult.ComponentCollaboratorDetail
{
    public class ComponentCollaboratorDetailDto
    {
        public int Id { get; set; }
        public string SubcomponentName { get; set; } = string.Empty;
        public List<ComponentCollaboratorConductDto>? ComponentCollaboratorConducts { get; set; }
    }
}
