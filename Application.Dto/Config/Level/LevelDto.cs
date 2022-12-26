
namespace Application.Dto.Config.Level
{
    using System.Text.Json.Serialization;
    public class LevelDto : BaseLevelDto
    {
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime CreateDate { get; set; }
    }
}
