using SharedKernell.Helpers;
using System.Text.Json.Serialization;

namespace Application.Dto.EvaResult.Evaluation
{
    public class EvaluationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool HasComponentCorporateObjectives { get; set; }
        public bool HasComponentAreaObjectives { get; set; }
        public bool HasComponentCompetencies { get; set; }
        public string RangeDate { get; set; } = string.Empty;

        public bool IsActive => CurrentDate >= StartDate && CurrentDate <= EndDate;

        [JsonIgnore] public DateTime CurrentDate { get; set; } = DateTime.UtcNow.GetDatePeru();
        [JsonIgnore] public DateTime StartDate { get; set; }
        [JsonIgnore] public DateTime EndDate { get; set; }
    }
}
