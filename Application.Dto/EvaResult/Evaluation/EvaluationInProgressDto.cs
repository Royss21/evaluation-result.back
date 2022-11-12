namespace Application.Dto.EvaResult.Evaluation
{
    public class EvaluationInProgressDto : BaseEvaluationDto
    {
        public bool HasComponentCorporateObjectives { get; set; }
        public bool HasComponentAreaObjectives { get; set; }
        public bool HasComponentCompetencies { get; set; }
        public string PeriodName { get; set; } = string.Empty;
        public string EvaluationName { get; set; } = string.Empty;
        public string RangeDate { get; set; } = string.Empty;

    }
}
