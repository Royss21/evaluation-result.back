
namespace Application.Dto.Config.ParameterRange
{
    using System.Text.Json.Serialization;
    public class ParameterRangeDto : BaseParameterRangeDto
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
