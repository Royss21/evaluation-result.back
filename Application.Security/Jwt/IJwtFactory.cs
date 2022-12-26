
namespace Application.Security.Jwt
{
    using Application.Security.Entities;
    public interface IJwtFactory
    {
        UserTokenApp GetJwt(UserClaim appUser, bool onlyToken = true);
    }
}