using Application.Dto.EvaResult.ComponentCollaboratorConduct;

namespace Application.Dto.EvaResult.ComponentCollaboratorDetail
{
    public class ComponentCollaboratorDetailEvaluateDto
    {
        public int ComponentCollaboratorDetailId { get; set; }
        public decimal ValueResult { get; set; }
        public List<ComponentCollaboratorConductEvaluateDto> ComponentCollaboratorConductsEvaluateDto { get; set; }
    }
}
