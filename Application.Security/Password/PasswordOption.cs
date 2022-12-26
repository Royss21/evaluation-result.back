
namespace Application.Security.Password
{
    public class PasswordOption
    {
        public List<PasswordOptionsEncrypt> Options { get; set; }
    }

    public class PasswordOptionsEncrypt 
    {
        public int SaltSize { get; set; }
        public int KeySize { get; set; }
        public int Iterations { get; set; }
    }
}