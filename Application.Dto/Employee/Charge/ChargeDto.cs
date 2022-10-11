
namespace Application.Dto.Employee.Charge
{
    using System.Text.Json.Serialization;
    public class ChargeDto : BaseChargeDto
    {
        public int Id { get; set; }

        [JsonIgnore]
        public DateTimeOffset CreateDate { get; set; }
    }
}
