using System.Text.Json.Serialization;

namespace Application.Dto.EvaResult.Period
{
    public class PeriodDto : BasePeriodDto
    {
        public int Id { get; set; }
        public string RangeDate { get; set; } = string.Empty;
        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
