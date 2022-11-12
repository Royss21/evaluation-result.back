
namespace Application.Dto.EvaResult.RangeParameter
{
    using System.Text.Json.Serialization;
    public class RangeParameterDto : BaseRangeParameterDto
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
