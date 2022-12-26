
namespace Application.Dto.Config.SubcomponentValue
{
    using System.Text.Json.Serialization;
    public class SubcomponentValueDto : BaseSubcomponentValueDto
    {
        public Guid Id { get; set; }
        public string ChargeName { get; set; } = string.Empty;

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
