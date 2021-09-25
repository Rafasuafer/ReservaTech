using System.Linq;
using Entities.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using reserbit_api.Models;
using Services;
using System.Threading.Tasks;
using reserbit_api.Controllers.API;
using Microsoft.Extensions.Logging;
using reserbit_api.Areas.Identity.Pages.Account;

namespace reserbit_api.Controllers.MVC
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private ApplicationUserApiController userController; 
        public AdminController(
            ApplicationUserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LoginModel> logger
            )
        {
	        userController = new ApplicationUserApiController(userManager, signInManager, logger);
            _roleManager = roleManager;
        }


        public IActionResult Index()
        {
	        return View();
        }
        public IActionResult RoleList()
        {
	        var roles = _roleManager.Roles;
	        return View(roles);
        }
        [HttpGet]
        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreate(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newRole = new IdentityRole() { Name = model.RoleName };
                IdentityResult result = await _roleManager.CreateAsync(newRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "Admin");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);

        }

        public IActionResult UserList()
        {
	        var users = userController.GetAll();
            return View(users);
        }

        public IActionResult UserCreate()
        {
	        return View();
        }
    }
}