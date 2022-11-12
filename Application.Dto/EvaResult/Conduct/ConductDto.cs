
namespace Application.Dto.EvaResult.Conduct
{
    using System.Text.Json.Serialization;
    public class ConductDto : BaseConductDto
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
