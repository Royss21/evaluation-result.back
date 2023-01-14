using Application.Dto.EvaResult.Evaluation;
using SharedKernell.Helpers;
using System.Text.Json.Serialization;

namespace Application.Dto.EvaResult.Period
{
    public class PeriodInProgressDto 
    {
        public int PeriodId { get; set; }
        public string PeriodName { get; set; } = string.Empty;
        public EvaluationDto Evaluation { get; set; }
    }
}
