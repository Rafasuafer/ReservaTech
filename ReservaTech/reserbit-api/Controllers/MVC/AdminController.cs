using Entities.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using reserbit_api.Areas.Identity.Pages.Account;
using reserbit_api.Controllers.API;
using reserbit_api.Models;
using reserbit_api.Models.User;
using Services;
using System.Threading.Tasks;

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
                    return RedirectToAction("Admin", "RoleList");
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

        [HttpGet]
        public IActionResult UserCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserCreate(CreateUserDto model)
        {
            if (ModelState.IsValid)
            {
                var result = await userController.NewUser(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("Admin", "UserList");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
    }
}