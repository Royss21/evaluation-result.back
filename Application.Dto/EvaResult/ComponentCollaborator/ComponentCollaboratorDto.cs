
namespace Application.Dto.EvaResult.ComponentCollaborator
{
    using Application.Dto.EvaResult.ComponentCollaboratorDetail;
    using Application.Dto.EvaResult.EvaluationCollaborator;
    public class ComponentCollaboratorDto: CollaboratorInformationDto
    {
        public Guid Id { get; set; }
        public int EvaluationComponentId { get; set; }
        public int EvaluationComponentStageId { get; set; }
        public int StageId { get; set; }
        public int ComponentId { get; set; }
        public string Comment { get; set; } = string.Empty;
        public Guid EvaluationCollaboratorId { get; set; }

        
        public string StatusName { get; set; } = string.Empty;
        public int StatusId { get; set; }

        public List<ComponentCollaboratorDetailDto> ComponentCollaboratorDetails { get; set; }
    }
}
