
namespace Application.Dto.Entidades.MarcaVehiculo
{
    using System.Text.Json.Serialization;
    public class MarcaVehiculoDto : BaseMarcaVehiculo
    {
        public int Id { get; set; }

        [JsonIgnore]
        public DateTimeOffset FechaCrea { get; set; }
    }
}
