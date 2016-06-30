using Microsoft.AspNet.Identity.EntityFramework;

namespace Sinina.OnlineShop.API.Authentication
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext() : base("AuthContext")
        {

        }
    }
}