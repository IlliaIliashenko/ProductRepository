using System.Collections.Generic;

namespace ProductApp.BLL.Models
{
    public class UserDomain
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<UserRoleDomain> UserRoles { get; set; }
    }
}