namespace Application.Dto.Config.Subcomponent
{
    public abstract class BaseSubcomponentDto
    {
        public int ComponentId { get; set; }
        public int? AreaId { get; set; }
        public Guid? FormulaId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
