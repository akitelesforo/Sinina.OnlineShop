using Microsoft.AspNet.Identity.EntityFramework;
using Sinina.OnlineShop.API.Authentication.Entities;
using System.Data.Entity;

namespace Sinina.OnlineShop.API.Authentication
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext() : base("AuthContext")
        {

        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}