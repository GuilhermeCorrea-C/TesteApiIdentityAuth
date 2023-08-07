using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TesteAPIBearer.Services.Interfaces;

namespace TesteAPIBearer.Services
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthenticateService(SignInManager<IdentityUser> signInManager, 
            UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        
        public async Task<bool> Authenticate(string email, string senha)
        {
            var log = await _signInManager.PasswordSignInAsync(email, senha, false, lockoutOnFailure: false);
            return log.Succeeded;
        }

        public async Task<bool> RegisterUser(string email, string senha)
        {
            var appUser = new IdentityUser
            {
                UserName = email,
                Email = email
            };

            Console.WriteLine($"{appUser.UserName} {appUser.Email} {senha}");

            var register = await _userManager.CreateAsync(appUser, senha);
            Console.WriteLine($" resultado: {register}");

            if(register.Succeeded)
            {
                await _signInManager.SignInAsync(appUser, isPersistent: false);
                return true;
            }

            return false;
            
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}