
namespace Application.Dto.Entidades.Tamanio
{
    using System.Text.Json.Serialization;
    public class TamanioDto : BaseTamanio
    {
        public int Id { get; set; }
        public Guid CompaniaId { get; set; }

        [JsonIgnore]
        public DateTimeOffset FechaCrea { get; set; }
    }
}
