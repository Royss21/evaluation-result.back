namespace Application.Dto.EvaResult.ComponentStage
{
    public class BaseComponentStageDto
    {
        public int EvaluationComponentId { get; set; }
        public int StageId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
