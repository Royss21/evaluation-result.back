
namespace Application.Dto.Employee.Area
{
    using System.Text.Json.Serialization;
    public class AreaDto : BaseAreaDto
    {
        public int Id { get; set; }
        public string GerencyName { get; set; } = string.Empty;

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
