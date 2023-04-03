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

            public async Task<bool> GiveRole(string userEmail, string role)
            {
                var user = await _userManager.FindByEmailAsync(userEmail);
                if (user == null)
                {
                    return false;
                }

			    if (await _userManager.IsInRoleAsync(user, "Admin"))
			    {
                    return false;
			    }

			    var roleExists = await _roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    return false;
                }

                var roles =  await _userManager.GetRolesAsync(user);

			    var result = await _userManager.RemoveFromRolesAsync(user, roles);

                if(result.Succeeded)
                {
				    var addToRoleResult = await _userManager.AddToRoleAsync(user, role);
				    if (!addToRoleResult.Succeeded)
				    {
					    return false;
				    }

				    return true;
			    }
                else
                {
                return false;
                }

			    
            }

            public async Task<bool> AddRole(string role)
            {
                
                var roleExists = await _roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                    return true;
                }
                return false;
            }

            public List<IdentityRole> GetRoles()
            {
               var roles = _roleManager.Roles.ToList();
               return roles;
            }
    }
}
