
namespace Application.Dto.Employee.Employee
{
    using System.Text.Json.Serialization;
    public class CollaboratorDto : BaseCollaboratorDto
    {
        public string Id { get; set; } = string.Empty;

        [JsonIgnore]
        public DateTimeOffset CreateDate { get; set; }
    }
}
