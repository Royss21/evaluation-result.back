
namespace Application.Dto.Config.ParameterValue
{
    using System.Text.Json.Serialization;
    public class ParameterValueDto : BaseParameterValueDto
    {
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
