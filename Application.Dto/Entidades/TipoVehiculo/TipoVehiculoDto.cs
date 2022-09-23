
namespace Application.Dto.Entidades.TipoVehiculo
{
    using System.Text.Json.Serialization;
    public class TipoVehiculoDto : BaseTipoVehiculo
    {
        public int Id { get; set; }

        [JsonIgnore]
        public DateTimeOffset FechaCrea { get; set; }
    }
}
