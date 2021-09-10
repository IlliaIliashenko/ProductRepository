using System.Threading.Tasks;
using ProductApp.BLL.Models;

namespace ProductApp.BLL.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> Register(UserDomain userDomain);
        Task<TokenDomain> Login(LoginUserDomain loginUserDomain);
    }
}