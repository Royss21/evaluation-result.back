
namespace Application.Dto.Entidades.Color
{
    using System.Text.Json.Serialization;
    public class ImagenDto : BaseColor
    {
        public int Id { get; set; }

        [JsonIgnore]
        public DateTimeOffset FechaCrea { get; set; }
    }
}
