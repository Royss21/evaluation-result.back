
namespace Application.Dto.Employee.Collaborator
{
    using System.Text.Json.Serialization;
    public class CollaboratorNotInEvaluationDto
    {
        public Guid Id { get; set; }
        public string ChargeName { get; set; } = string.Empty;
        public string HierarchyName { get; set; } = string.Empty;
        public string GerencyName { get; set; } = string.Empty;
        public string AreaName { get; set; } = string.Empty;
        public string LevelName { get; set; } = string.Empty;
        public string DocumentNumber { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
