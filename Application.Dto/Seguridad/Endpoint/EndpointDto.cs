
namespace Application.Dto.Seguridad.Endpoint
{
    using System.Text.Json.Serialization;
    public class EndpointDto : BaseEndpoint
    {
        public Guid Id { get; set; }

        [JsonIgnore]
        public DateTimeOffset FechaCrea { get; set; }
    }
}
