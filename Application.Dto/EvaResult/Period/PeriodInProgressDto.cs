using Application.Dto.EvaResult.Evaluation;

namespace Application.Dto.EvaResult.Period
{
    public class PeriodInProgressDto 
    {
        public int PeriodId { get; set; }
        public string PeriodName { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public EvaluationCurrentDto EvaluationCurrent { get; set; }
    }
}
