using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ProductApp.DAL.Models.Authentication
{
    public class RoleEntity : IdentityRole<int>
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<UserRoleEntity> UserRoles { get; set; }

    }
}