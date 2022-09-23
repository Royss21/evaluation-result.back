
namespace Application.Security.Contrasenia
{
    public interface IContraseniaFabrica
    {
        (int, string) Hash(string contrasenia);
        bool Verificar(string hash, string contrasenia, int indice);
    }
}