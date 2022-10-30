
namespace Application.Dto.EvaResult.Evaluation
{
    using Application.Dto.EvaResult.ComponentStage;
    using Application.Dto.EvaResult.EvaluationComponent;
    public class EvaluationCreateDto : BaseEvaluationDto
    {
        public bool IsEvaluationTest { get; set; }
        public List<EvaluationComponentCreateDto> EvaluationComponentsDto { get; set; }
        public List<ComponentStageCreateDto> ComponentStagesDto { get; set; }
    }
}
