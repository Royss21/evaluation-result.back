
namespace Application.Dto.EvaResult.Subcomponent
{
    using System.Text.Json.Serialization;
    public class SubcomponentDto : BaseSubcomponentDto
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
