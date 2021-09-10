using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductApp.DAL.Data.Repository.Interfaces;
using ProductApp.DAL.Models.Authentication;

namespace ProductApp.DAL.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<RoleEntity> _roleManager;

        public UserRepository(ApplicationContext context, UserManager<UserEntity> userManager, RoleManager<RoleEntity> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> UserExistAsync(string login)
        {
            var result = await _context.UserEntities.AsNoTracking().FirstOrDefaultAsync(u => u.Login == login);
           
            return result != null;
        }

        public async Task CreateUserAsync(UserEntity userEntity)
        {
            userEntity.UserRoles.Add(new UserRoleEntity(){RoleId = 2, User = userEntity});
            await _context.UserEntities.AddAsync(userEntity);
            await _context.SaveChangesAsync();

        }
        public async Task<IEnumerable<string>> GetUserRole(UserEntity userEntity)
        {
            var result = await _context.UserEntities.Include(u => u.UserRoles).ThenInclude(r => r.Role)
                .FirstOrDefaultAsync(u => u.Login == userEntity.Login);

            var roleList = result?.UserRoles.Select(u => u.Role.RoleName);

            return roleList;

        }

        public async Task<UserEntity> GetUserAsync(string login, string password)
        {
            var result = await _context.UserEntities.Include(u => u.UserRoles).ThenInclude(r => r.Role)
                .FirstOrDefaultAsync(u => u.Login == login);

            if (result == null) return null;

            var hasher = new PasswordHasher<UserEntity>();
            var passwordVerification = hasher.VerifyHashedPassword(null, result.PasswordHash, password);

            return passwordVerification == PasswordVerificationResult.Success ? result : null;

        }


    }
}