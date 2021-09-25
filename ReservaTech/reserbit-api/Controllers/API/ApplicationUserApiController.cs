using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Core;
using Microsoft.AspNetCore.Authorization;
using Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using reserbit_api.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Authentication;
using reserbit_api.Models.Loggin;

namespace reserbit_api.Controllers.API
{
	[Route("~/api/users")]
	public class ApplicationUserApiController : Controller
	{
		private readonly ApplicationUserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public ApplicationUserApiController(
			ApplicationUserManager<ApplicationUser> userManager, 
			SignInManager<ApplicationUser> signInManager,
			ILogger<LoginModel> logger)
		{
			_userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

		[HttpGet]
		[Route("~/api/users")]
		public IEnumerable<ApplicationUser> GetAll()
		{
			return _userManager.Users;
		}

		[HttpPost]
		[Route("~/api/user/login")]
		[AllowAnonymous]
		public async Task<IActionResult> Login([FromBody]LoginInputModel Input)
		{

            IList<AuthenticationScheme> ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return Ok("Success");
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return BadRequest("Blocked");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return BadRequest("Invalid");
                }
            }
            return BadRequest("Vino null");
        }

	}
}
