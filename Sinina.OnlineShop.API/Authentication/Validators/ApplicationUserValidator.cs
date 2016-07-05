﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Sinina.OnlineShop.API.Authentication.Validators
{
    public class ApplicationUserValidator: UserValidator<IdentityUser>
    {
 
        List<string> _allowedEmailDomains = new List<string> { "outlook.com", "hotmail.com", "gmail.com", "yahoo.com" };

        public ApplicationUserValidator(ApplicationUserManager appUserManager)
            : base(appUserManager)
        {
        }

        public override async Task<IdentityResult> ValidateAsync(IdentityUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);
 
            var emailDomain = user.Email.Split('@')[1];
 
            if (!_allowedEmailDomains.Contains(emailDomain.ToLower()))
            {
                var errors = result.Errors.ToList();
 
                errors.Add(String.Format("Email domain '{0}' is not allowed", emailDomain));
 
                result = new IdentityResult(errors);
            }
 
            return result;
        }
    }
}