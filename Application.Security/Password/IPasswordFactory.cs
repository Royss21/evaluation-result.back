
namespace Application.Security.Password
{
    public interface IPasswordFactory
    {
        (int, string) Hash(string password);
        bool VerifyPassword(string hash, string password, int index);
    }
}