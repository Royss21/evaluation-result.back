using System.Text.Json.Serialization;

namespace Application.Dto.EvaResult.Period
{
    public class PeriodDto : BasePeriodDto
    {
        public int Id { get; set; }
        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
