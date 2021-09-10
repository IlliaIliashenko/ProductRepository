using System.Collections.Generic;

namespace ProductApp.BLL.Models
{
    public class TokenDomain
    {
        public string AccessToken { get; set; }
        public string UserName { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}