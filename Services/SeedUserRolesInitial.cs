using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TesteAPIBearer.Services.Interfaces;

namespace TesteAPIBearer.Services
{
    public class SeedUserRolesInitial : ISeedUserRolesInitial
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRolesInitial(UserManager<IdentityUser> userManager, 
                                    RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
            if(! await _roleManager.RoleExistsAsync("User")){
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                role.ConcurrencyStamp = Guid.NewGuid().ToString();

                IdentityResult roleResult = await _roleManager.CreateAsync(role); 
            }

             if(! await _roleManager.RoleExistsAsync("Admin")){
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                role.ConcurrencyStamp = Guid.NewGuid().ToString();

                IdentityResult roleResult = await _roleManager.CreateAsync(role);
            }
        }

        public async Task SeedUsersAsync()
        {
            if(await _userManager.FindByEmailAsync("user@ucl.br") == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "user@ucl.br";
                user.Email = "user@ucl.br";
                user.NormalizedUserName = "USER@UCL.BR";
                user.NormalizedEmail = "USER@UCL.BR";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = await _userManager.CreateAsync(user, "Usuario1@ucl");

                if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                }
            }

            if(await _userManager.FindByEmailAsync("admin@ucl.br") == null)
            {
                IdentityUser admin = new IdentityUser();
                admin.UserName = "admin@ucl.br";
                admin.Email = "admin@ucl.br";
                admin.NormalizedUserName = "ADMIN@UCL.BR";
                admin.NormalizedEmail = "ADMIN@UCL.BR";
                admin.EmailConfirmed = true;
                admin.LockoutEnabled = false;
                admin.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = await _userManager.CreateAsync(admin, "Admin1@ucl");

                if(result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}