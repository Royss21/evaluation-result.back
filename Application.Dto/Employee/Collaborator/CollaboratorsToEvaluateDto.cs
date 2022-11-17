namespace Application.Dto.Employee.Collaborator
{
    public class CollaboratorsToEvaluateDto
    {
        public Guid CollaboratorId { get; set; }
        public string GerencyName { get; set; } = string.Empty;
        public string ChargeName { get; set; } = string.Empty;
        public string AreaName { get; set; } = string.Empty;
        public string HierarchyName { get; set; } = string.Empty;
        public string LevelName { get; set; } = string.Empty;
    }
}
