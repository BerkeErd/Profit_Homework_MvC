using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Profit_Homework_MvC.Services;

namespace Profit_Homework_MvC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AdminRoleService _adminRoleService;

        public AdminController(AdminRoleService adminRoleService)
        {
            _adminRoleService = adminRoleService;
        }

        public IActionResult Index()
        {
            var roles = _adminRoleService.GetRoles();
            return View(roles);
        }

        public async Task<IActionResult> MakeUserAdmin(string userEmail)
        {
            var result = await _adminRoleService.MakeUserAdmin(userEmail);
            if (result)
            {
                return Ok("User has been given Admin role.");
            }
            else
            {
                return BadRequest("Could not give Admin role to user.");
            }
        }

        public async Task<IActionResult> AddRole(string role)
        {
            try
            {
                var result = await _adminRoleService.AddRole(role);
                if(result)
                {
                    return Ok(role + " Rolü başarıyla eklendi.");
                }
                else
                {
                    return Ok(role + " Eklenemedi");
                }
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
            
        } 
        public async Task<IActionResult> GiveRole(string roleName, string email)
        {
            try
            {
                var result = await _adminRoleService.GiveRole(email, roleName);
                if(result)
                {
                    return Ok(roleName + " Rolü başarıyla "+ email + "kullanıcısına verildi.");
                }
                else
                {
                    return Ok("Başaramadın.");
                }
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
            
        }
    }
}
