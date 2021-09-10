using System.Threading.Tasks;
using ProductApp.DAL.Models.Authentication;

namespace ProductApp.DAL.Data.Repository.Interfaces
{
    public interface IRoleRepository
    {
        Task<RoleEntity> GetRoleAsync();
    }
}