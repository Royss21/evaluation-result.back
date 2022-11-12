namespace Application.Dto.EvaResult.Evaluation
{
    public abstract class BaseEvaluationDto
    {
        public int PeriodId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Weight { get; set; }
    }
}
