
namespace Application.Dto.EvaResult.SubcomponentValue
{
    using System.Text.Json.Serialization;
    public class SubcomponentValueDto : BaseSubcomponentValueDto
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
