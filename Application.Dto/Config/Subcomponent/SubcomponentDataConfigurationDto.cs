
namespace Application.Dto.Config.Subcomponent
{
    using Application.Dto.Config.SubcomponentValue;
    public class SubcomponentDataConfigurationDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;    
        public int? ComponentId { get; set; }
        public string AreaName { get; set; } = string.Empty;
        public Guid FormulaId{ get; set; }
        public string FormulaName { get; set; } = string.Empty;
        public string FormulaQuery { get; set; } = string.Empty;
        public List<SubcomponentValueDataConfigurationDto> SubcomponentValues { get; set; }
    }
}
