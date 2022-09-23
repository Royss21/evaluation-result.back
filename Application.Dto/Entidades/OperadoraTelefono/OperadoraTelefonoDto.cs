
namespace Application.Dto.Entidades.OperadoraTelefono
{
    using System.Text.Json.Serialization;
    public class OperadoraTelefonoDto : BaseOperadoraTelefono
    {
        public int Id { get; set; }

        [JsonIgnore]
        public DateTimeOffset FechaCrea { get; set; }
    }
}
