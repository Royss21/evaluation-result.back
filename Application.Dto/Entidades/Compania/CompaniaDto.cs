
namespace Application.Dto.Entidades.Compania
{
    using System.Text.Json.Serialization;
    public class CompaniaDto : BaseCompania
    {
        public Guid Id { get; set; }

        public int? ImagenLogoId { get; set; }

        [JsonIgnore]
        public DateTimeOffset FechaCrea { get; set; }
    }
}
