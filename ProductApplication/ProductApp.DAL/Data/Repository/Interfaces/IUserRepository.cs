using System.Collections.Generic;
using System.Threading.Tasks;
using ProductApp.DAL.Models.Authentication;

namespace ProductApp.DAL.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> UserExistAsync(string login);
        Task CreateUserAsync(UserEntity userEntity);
        Task<UserEntity> GetUserAsync(string login, string password);
        Task<IEnumerable<string>> GetUserRole(UserEntity userEntity);
    }
}