

namespace Application.Security.Password
{

    using Microsoft.Extensions.Options;
    using System.Security.Cryptography;

    public class PasswordFactory : IPasswordFactory
    {
        private readonly PasswordOption _options;
        public PasswordFactory(IOptions<PasswordOption> options)
        {
            _options = options.Value;
        }

        public bool VerifyPassword(string hash, string password, int index)
        {
            var parts = hash.Split('.');

            if (parts.Length != 3)
                throw new Exception("La contraseña no tiene el formato correcto");

            var opcion = _options.Options[index];
            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            using (var algorithm = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                var keyToCheck = algorithm.GetBytes(opcion.KeySize);
                return keyToCheck.SequenceEqual(key);
            }
        }

        public (int , string) Hash(string password)
        {
            Random random = new Random();
            int index = random.Next(1, _options.Options.Count);

            var opcion = _options.Options[index];

            using (var algorithm = new Rfc2898DeriveBytes(password, opcion.SaltSize, opcion.Iterations))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(opcion.KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return (index, $"{opcion.Iterations}.{salt}.{key}");
            }
        }
    }
}