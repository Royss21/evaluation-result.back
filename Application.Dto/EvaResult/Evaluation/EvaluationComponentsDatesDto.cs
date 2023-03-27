using Application.Dto.EvaResult.EvaluationComponentStage;
using SharedKernell.Helpers;
using System.Text.Json.Serialization;

namespace Application.Dto.EvaResult.Evaluation
{
    public class EvaluationComponentsDatesDto
    {
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<ComponentStagesDates> ComponentStagesDates  { get; set; }
    }

    public class ComponentStagesDates : BaseEvaluationComponentStageDto
    {
        public int Id { get; set; }
        public int ComponentId { get; set; }
    }
}
