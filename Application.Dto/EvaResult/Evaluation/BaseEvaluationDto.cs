namespace Application.Dto.EvaResult.Evaluation
{
    public class BaseEvaluationDto
    {
        public int PeriodId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Weight { get; set; }
    }
}
