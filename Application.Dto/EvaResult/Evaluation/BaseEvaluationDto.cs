namespace Application.Dto.EvaResult.Evaluation
{
    public abstract class BaseEvaluationDto
    {
        public int PeriodId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Weight { get; set; }
    }
}
