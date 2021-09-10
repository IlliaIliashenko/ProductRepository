using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductApp.DAL.Data.Repository.Interfaces;
using ProductApp.DAL.Models.Authentication;

namespace ProductApp.DAL.Data.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationContext _context;

        public RoleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<RoleEntity> GetRoleAsync()
        {
            var role = await _context.RoleEntities.AsNoTracking().FirstOrDefaultAsync(r => r.RoleName == "Guest");

            return role;
        }
    }
}