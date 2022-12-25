using Application.Dto.EvaResult.Period;

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
        public int ComponentId { get; set; }
        public string ComponentName { get; set; } = string.Empty;
        public string RangeDate { get; set; } = string.Empty;

        public List<StageRangeDateDto> Stages { get; set; }
    }

    public class StageRangeDateDto
    {
        public int StageId { get; set; }
        public string StageName { get; set; } = string.Empty;
        public string RangeDate { get; set; } = string.Empty;
    }
}
