using Microsoft.AspNetCore.Identity;
using Profit_Homework_MvC.Models;
using System;
using System.Threading.Tasks;

namespace Profit_Homework_MvC.Services
{
    public class AdminRoleService
    {
       
            private readonly UserManager<IdentityUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;

            public AdminRoleService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
            {
                _userManager = userManager;
                _roleManager = roleManager;
            }

            public async Task<bool> MakeUserAdmin(string userEmail)
            {
                var user = await _userManager.FindByEmailAsync(userEmail);
                if (user == null)
                {
                    return false;
                }

                var roleExists = await _roleManager.RoleExistsAsync("Admin");
                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                var addToRoleResult = await _userManager.AddToRoleAsync(user, "Admin");
                if (!addToRoleResult.Succeeded)
                {
                    return false;
                }

                return true;
            }
        
    }
}
