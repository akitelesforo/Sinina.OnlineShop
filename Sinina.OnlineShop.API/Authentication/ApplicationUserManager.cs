using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Sinina.OnlineShop.API.Authentication.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sinina.OnlineShop.API.Authentication
{
    public class ApplicationUserManager : UserManager<IdentityUser>
    {
        public ApplicationUserManager(IUserStore<IdentityUser> store)
            : base(store)
        {
            this.UserTokenProvider = new TotpSecurityStampBasedTokenProvider<IdentityUser, string>();
            this.EmailService = new Sinina.OnlineShop.API.Services.EmailService();
            //Configure validation logic for usernames
            this.UserValidator = new ApplicationUserValidator(this)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            //Configure validation logic for passwords
            this.PasswordValidator = new ApplicationPasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = false,
                RequireUppercase = false,
            };
        }
    }
}