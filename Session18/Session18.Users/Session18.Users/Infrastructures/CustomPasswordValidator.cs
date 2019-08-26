using Microsoft.AspNetCore.Identity;
using Session18.Users.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Session18.Users.Infrastructures
{
    public class CustomUserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager,
             AppUser user)
        {
            if (user.Email.ToLower().EndsWith("@nikamooz.com"))
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "EmailDomainError",
                    Description = "Only nikamooz.com email addresses are allowed"
                }));
            }
        }
    }
    public class CustomPasswordValidator2:PasswordValidator<AppUser>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            IdentityResult result = await base.ValidateAsync(manager, user, password);

            List<IdentityError> errors = result.Succeeded ?
                new List<IdentityError>() : result.Errors.ToList();

            //if (password.ToLower().Contains(user.UserName.ToLower()))
            //{
            //    errors.Add(new IdentityError
            //    {
            //        Code = "PasswordContainsUserName",
            //        Description = "Password cannot contain username"
            //    });
            //}
            if (password.Contains("12345"))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsSequence",
                    Description = "Password cannot contain numeric sequence"
                });
            }
            return errors.Count == 0 ? IdentityResult.Success
            : IdentityResult.Failed(errors.ToArray());
        }
    }
    public class CustomPasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager,
                AppUser user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();
            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new IdentityError
                {
                    Code = "PasswordContainsUserName",
                    Description = "Password cannot contain username"
                });
            }
            //if (password.Contains("12345"))
            //{
            //    errors.Add(new IdentityError
            //    {
            //        Code = "PasswordContainsSequence",
            //        Description = "Password cannot contain numeric sequence"
            //    });
            //}
            return Task.FromResult(errors.Count == 0 ?
            IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
