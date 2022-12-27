
namespace Application.Dto.EvaResult.Evaluation
{
    using Application.Dto.EvaResult.EvaluationComponent;
    using Application.Dto.EvaResult.EvaluationComponentStage;

    public class EvaluationCreateDto : BaseEvaluationDto
    {
        public bool IsEvaluationTest { get; set; }
        public List<EvaluationComponentCreateDto> EvaluationComponents { get; set; }
        public List<EvaluationComponentStageCreateDto> EvaluationComponentStages { get; set; }
    }
}
