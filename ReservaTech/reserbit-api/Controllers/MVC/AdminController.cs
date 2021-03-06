using Entities.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using reserbit_api.Areas.Identity.Pages.Account;
using reserbit_api.Controllers.API;
using reserbit_api.Models;
using Services;
using System.Threading.Tasks;
using Entities.DTO;

namespace reserbit_api.Controllers.MVC
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationUserApiController appplicationUserController;

        public AdminController(
            ApplicationUserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<LoginModel> logger
            )
        {
	        appplicationUserController = new ApplicationUserApiController(userManager, signInManager);
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
                    return RedirectToAction("RoleList", "Admin");
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
	        var users = appplicationUserController.GetAll();
            return View(users);
        }

        [HttpGet]
        public IActionResult UserCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserCreate(CreateUserViewModel model)
        {
	        if (ModelState.IsValid)
	        {
		        var result = await appplicationUserController.Register(new CreateUserDto
		        {
			        Email = model.Email,
			        Password = model.Password
		        });

		        if (result.Succeeded)
		        {
			        return RedirectToAction("UserList", "Admin");
		        }

		        foreach (var error in result.Errors)
		        {
			        ModelState.AddModelError("", error.Description);
		        }
            }


            return View(model);
        }
        public IActionResult UserEdit()
        {
	        return View();
        }
    }
}