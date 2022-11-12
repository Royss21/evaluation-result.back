
namespace Application.Dto.EvaResult.ParameterValue
{
    using System.Text.Json.Serialization;
    public class ParameterValueDto : BaseParameterValueDto
    {
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
