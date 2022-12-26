using Application.Dto.EvaResult.ComponentCollaboratorConduct;

namespace Application.Dto.EvaResult.ComponentCollaboratorDetail
{
    public class ComponentCollaboratorDetailEvaluateDto
    {
        public int Id { get; set; }
        public decimal ValueResult { get; set; }
        public List<ComponentCollaboratorConductEvaluateDto>? ComponentCollaboratorConductsEvaluate { get; set; }
    }
}
