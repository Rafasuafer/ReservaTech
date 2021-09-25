using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Core;
using Microsoft.AspNetCore.Authorization;
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
		
	}
}
