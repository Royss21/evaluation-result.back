
namespace Application.Dto.Config.Area
{
    using System.Text.Json.Serialization;
    public class AreaResDto : BaseAreaDto
    {
        public int Id { get; set; }

        [JsonIgnore]
        public DateTimeOffset CreateDate { get; set; }
    }
}
