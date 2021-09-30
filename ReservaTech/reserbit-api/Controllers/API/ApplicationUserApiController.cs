using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Core;
using Entities.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using reserbit_api.Models;
using Services;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace reserbit_api.Controllers.API
{
	[Route("~/api/users")]
	public class ApplicationUserApiController : Controller
	{
		private readonly ApplicationUserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public ApplicationUserApiController(
			ApplicationUserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpPost]
		[Route("~/api/user/login")]
		[AllowAnonymous]
		public async Task<SignInResult> Login([FromBody]LoginRequestDto dto)
		{
			//TODO: External Login
			//var externalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

			return await _signInManager.PasswordSignInAsync(dto.Email, dto.Password, dto.RememberMe, lockoutOnFailure: false);
		}

		[HttpGet]
		[Route("~/api/users/all")]
		public IEnumerable<ApplicationUser> GetAll()
		{
			return _userManager.Users;
		}

		[HttpPost]
		[Route("~/api/user/register")]
		public async Task<IdentityResult> Register(CreateUserDto dto)
		{
			return await _userManager.CreateAsync(
				new ApplicationUser
				{
					UserName = dto.Email,
					Email = dto.Email
				}, 
				dto.Password);
		}


	}
}
