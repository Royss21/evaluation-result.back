
namespace Application.Security.JWT
{
    using Application.Security.Entidades;
    public interface IJwtFabrica
    {
        UsuarioTokenApp ObtenerJwt(UsuarioClaim appUser, bool soloToken = true);
    }
}