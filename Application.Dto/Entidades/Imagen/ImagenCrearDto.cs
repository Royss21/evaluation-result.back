using Microsoft.AspNetCore.Http;

namespace Application.Dto.Entidades.Color
{
    public class ImagenCrearDto 
    {
        public IFormFile Archivo { get; set; }
    }
}
