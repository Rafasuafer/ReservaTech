using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Core;
using Microsoft.AspNetCore.Authorization;
using Services;

namespace WebApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class ReserBitController : ControllerBase
	{
		protected readonly ApplicationUserManager<ApplicationUser> ApplicationUserManager;
	}
}
