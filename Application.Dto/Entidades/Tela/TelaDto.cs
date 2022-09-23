
namespace Application.Dto.Entidades.Tela
{
    using System.Text.Json.Serialization;
    public class TelaDto : BaseTela
    {
        public int Id { get; set; }
        public Guid CompaniaId { get; set; }

        [JsonIgnore]
        public DateTimeOffset FechaCrea { get; set; }
    }
}
