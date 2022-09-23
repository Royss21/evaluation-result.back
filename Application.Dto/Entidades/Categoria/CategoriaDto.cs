
namespace Application.Dto.Entidades.Categoria
{
    using System.Text.Json.Serialization;
    public class CategoriaDto : BaseCategoria
    {
        public int Id { get; set; }
        public Guid CompaniaId { get; set; }

        [JsonIgnore]
        public DateTimeOffset FechaCrea { get; set; }
    }
}
