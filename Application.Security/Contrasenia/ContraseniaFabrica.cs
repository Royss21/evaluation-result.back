
namespace Application.Security.Contrasenia
{
    using Microsoft.Extensions.Options;
    using System.Security.Cryptography;

    public class ContraseniaFabrica : IContraseniaFabrica
    {
        private readonly ContraseniaOpciones _opciones;
        public ContraseniaFabrica(IOptions<ContraseniaOpciones> opciones)
        {
            _opciones = opciones.Value;
        }

        public bool Verificar(string hash, string contrasenia, int indice)
        {
            var parts = hash.Split('.');

            if (parts.Length != 3)
                throw new Exception("La contrasenia no tiene el formato correcto");

            var opcion = _opciones.Opciones[indice];
            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            using (var algorithm = new Rfc2898DeriveBytes(contrasenia, salt, iterations))
            {
                var keyToCheck = algorithm.GetBytes(opcion.TamanioLlave);
                return keyToCheck.SequenceEqual(key);
            }
        }

        public (int , string) Hash(string contrasenia)
        {
            Random random = new Random();
            int indice = random.Next(1, _opciones.Opciones.Count);

            var opcion = _opciones.Opciones[indice];

            //PBKDF2 implementacion
            using (var algorithm = new Rfc2898DeriveBytes(contrasenia, opcion.TamanioSalto, opcion.Iteraciones))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(opcion.TamanioLlave));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return (indice, $"{opcion.Iteraciones}.{salt}.{key}");
            }
        }
    }
}