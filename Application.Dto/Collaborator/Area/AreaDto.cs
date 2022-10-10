
namespace Application.Dto.Employee.Area
{
    using System.Text.Json.Serialization;
    public class AreaDto : BaseAreaDto
    {
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
