using Application.Dto.EvaResult.ComponentCollaboratorDetail;

namespace Application.Dto.EvaResult.ComponentCollaborator
{
    public class ComponentCollaboratorEvaluateDto
    {
        public Guid ComponentCollaboratorId { get; set; }
        public int EvaluationComponentId { get; set; }
        public int EvaluationComponentStageId { get; set; }
        public int ComponentId { get; set; }
        public string Comment { get; set; } = string.Empty;
        public List<ComponentCollaboratorDetailEvaluateDto> ComponentCollaboratorDetailsEvaluateDto { get; set; }
    }
}
