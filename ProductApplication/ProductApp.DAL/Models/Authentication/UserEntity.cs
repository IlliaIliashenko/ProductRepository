using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ProductApp.DAL.Models.Authentication
{
    public class UserEntity : IdentityUser<int>
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}