
namespace Application.Dto.Employee.IdentityDocument
{
    using System.Text.Json.Serialization;
    public class IdentityDocumentDto : BaseIdentityDocumentDto
    {
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
