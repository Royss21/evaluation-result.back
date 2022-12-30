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
        public string Comment { get; set; } = string.Empty;
        public Guid EvaluationCollaboratorId { get; set; }

        public string GerencyName { get; set; } = string.Empty;
        public string ChargeName { get; set; } = string.Empty;
        public string AreaName { get; set; } = string.Empty;
        public string HierarchyName { get; set; } = string.Empty;
        public string LevelName { get; set; } = string.Empty;
        public string CollaboratorName { get; set; } = string.Empty;
        public string StatusName { get; set; } = string.Empty;
        public int StatusId { get; set; }

        public List<ComponentCollaboratorDetailDto> ComponentCollaboratorDetails { get; set; }
    }
}
