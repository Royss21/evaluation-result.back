
namespace Application.Dto.Employee.Collaborator
{
    using System.Text.Json.Serialization;
    public class CollaboratorDto : BaseCollaboratorDto
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
