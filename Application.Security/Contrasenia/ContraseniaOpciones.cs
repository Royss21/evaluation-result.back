using Microsoft.IdentityModel.Tokens;

namespace Application.Security.Contrasenia
{
    public class ContraseniaOpciones
    {
        public List<ContraseniaOpcionesEncriptado> Opciones { get; set; }
    }

    public class ContraseniaOpcionesEncriptado 
    {
        public int TamanioSalto { get; set; }
        public int TamanioLlave { get; set; }
        public int Iteraciones { get; set; }
    }
}