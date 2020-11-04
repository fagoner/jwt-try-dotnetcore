using JwtTry.Models;

namespace JwtTry.Managers
{

    public interface IJWTAuthenticationManager
    {
        string Authenticate(UserCred userCred);
    }

}