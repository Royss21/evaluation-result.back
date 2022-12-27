
namespace Application.Dto.Employee.Charge
{
    using System.Text.Json.Serialization;
    public class ChargeDto : BaseChargeDto
    {
        public int Id { get; set; }
        public string AreaName { get; set; } = string.Empty;
        public string HierarchyName { get; set; } = string.Empty;

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
