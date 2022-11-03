namespace Application.Dto.EvaResult.EvaluationComponentStage
{
    public class BaseEvaluationComponentStageDto
    {
        public int EvaluationComponentId { get; set; }
        public int StageId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
