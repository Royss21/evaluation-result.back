using Application.Dto.EvaResult.ComponentCollaboratorDetail;

namespace Application.Dto.EvaResult.ComponentCollaborator
{
    public class ComponentCollaboratorDto
    {
        public Guid Id { get; set; }
        public int EvaluationComponentId { get; set; }
        public int EvaluationComponentStageId { get; set; }
        public int StageId { get; set; }
        public int ComponentId { get; set; }

        public List<ComponentCollaboratorDetailDto> ComponentCollaboratorDetails { get; set; }
    }
}
