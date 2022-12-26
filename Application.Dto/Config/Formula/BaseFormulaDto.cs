namespace Application.Dto.Config.Formula
{
    public abstract class BaseFormulaDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string FormulaReal { get; set; } = string.Empty;
        public string FormulaQuery { get; set; } = string.Empty;
    }
}
