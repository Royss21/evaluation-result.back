namespace Application.Dto.EvaResult.Evaluation
{
    public class EvaluationCurrentDetailDto : EvaluationInProgressDto
    {
        public bool IsEnableImportLeaders { get; set; }
        public List<ComponentRangeDate> Components { get; set; }
        public List<StageRangeDate> StagesEvaluation { get; set; }
    }

    public class ComponentRangeDate
    {
        public int ComponentId { get; set; }
        public string ComponentName { get; set; } = string.Empty;
        public string RangeDate { get; set; } = string.Empty;

        public List<StageRangeDate> Stages { get; set; }
    }

    public class StageRangeDate
    {
        public int StageId { get; set; }
        public string StageName { get; set; } = string.Empty;
        public string RangeDate { get; set; } = string.Empty;
    }
}
