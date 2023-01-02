using Application.Dto.EvaResult.Period;
using Newtonsoft.Json;
using SharedKernell.Helpers;
using static iTextSharp.text.pdf.qrcode.Version;

namespace Application.Dto.EvaResult.Evaluation
{
    public class EvaluationCurrentDetailDto : PeriodInProgressDto
    {

        public bool IsEnableImportLeaders { get; set; }
        public List<ComponentRangeDateDto> Components { get; set; }
        public List<StageRangeDateDto> StagesEvaluation { get; set; }
    }

    public class ComponentRangeDateDto
    {
        public int EvaluationComponentId { get; set; }
        public int ComponentId { get; set; }
        public string ComponentName { get; set; } = string.Empty;
        public string RangeDate { get; set; } = string.Empty;
        public bool IsActive => CurrentDate >= StartDate && CurrentDate <= EndDate;

        [JsonIgnore] public DateTime CurrentDate { get; set; } = DateTime.UtcNow.GetDatePeru();
        [JsonIgnore] public DateTime StartDate { get; set; }
        [JsonIgnore] public DateTime EndDate { get; set; }

        public List<StageRangeDateDto> Stages { get; set; }
    }

    public class StageRangeDateDto
    {
        public int StageId { get; set; }
        public string StageName { get; set; } = string.Empty;
        public string RangeDate { get; set; } = string.Empty;
        public bool IsActive => CurrentDate >= StartDate && CurrentDate <= EndDate;

        [JsonIgnore] public DateTime CurrentDate { get; set; } = DateTime.UtcNow.GetDatePeru();
        [JsonIgnore] public DateTime StartDate { get; set; }
        [JsonIgnore] public DateTime EndDate { get; set; }

    }
}
