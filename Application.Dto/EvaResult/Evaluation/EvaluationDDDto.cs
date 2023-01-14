namespace Application.Dto.EvaResult.Evaluation
{
    public class EvaluationDDDto : BaseEvaluationDto
    {
        public Guid Id { get; set; }
        public string PeriodName { get; set; } = string.Empty;
    }
}
