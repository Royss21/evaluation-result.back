
namespace Application.Dto.EvaResult.Subcomponent
{
    public class SubcomponentWithFormulaDto
    {
        public int ComponentId { get; set; }
        public int? AreaId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
