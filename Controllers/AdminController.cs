using Microsoft.AspNetCore.Mvc;
using Profit_Homework_MvC.Services;

namespace Profit_Homework_MvC.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminRoleService _adminRoleService;

        public AdminController(AdminRoleService adminRoleService)
        {
            _adminRoleService = adminRoleService;
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
    }
}
