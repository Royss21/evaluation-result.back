
namespace Application.Dto.Entidades.Color
{
    using System.Text.Json.Serialization;
    public class ColorDto : BaseColor
    {
        public int Id { get; set; }
        public Guid CompaniaId { get; set; }

        [JsonIgnore]
        public DateTimeOffset FechaCrea { get; set; }
    }
}
