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

namespace reserbit_api.Controllers.API
{
	[Route("~/api/users")]
	public class ApplicationUserController : Controller
	{
		private readonly ApplicationUserManager<ApplicationUser> _userManager;

		public ApplicationUserController(ApplicationUserManager<ApplicationUser> userManager)
		{
			_userManager = userManager;
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
					Email = dto.Email
				}, 
				dto.Password);
		}


	}
}
