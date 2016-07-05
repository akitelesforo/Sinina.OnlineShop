using Microsoft.AspNet.Identity.EntityFramework;
using Sinina.OnlineShop.API.Authentication.Entities;
using System.Data.Entity;

namespace Sinina.OnlineShop.API.Authentication
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext() : base("AuthContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static AuthContext Create()
        {
            return new AuthContext();
        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}