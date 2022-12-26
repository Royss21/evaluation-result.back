
namespace Application.Dto.Config.Subcomponent
{
    using System.Text.Json.Serialization;
    public class SubcomponentDto : BaseSubcomponentDto
    {
        public Guid Id { get; set; }
        public string AreaName { get; set; } = string.Empty;
        public string FormulaName { get; set; } = string.Empty;
        public int ChargeCount { get; set; }
        public int ChargeCountAssigned { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
