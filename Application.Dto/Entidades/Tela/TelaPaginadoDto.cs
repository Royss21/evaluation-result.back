
namespace Application.Dto.Entidades.Tela
{
    using System.Text.Json.Serialization;
    public class TelaPaginadoDto : BaseTela
    {
        public int Id { get; set; }
        public int CantidadColores { get; set; }
        public Guid CompaniaId { get; set; }

        [JsonIgnore]
        public DateTimeOffset FechaCrea { get; set; }
    }
}
