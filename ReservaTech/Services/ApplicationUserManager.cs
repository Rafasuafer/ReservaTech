using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Services
{
	public class ApplicationUserManager<TUser> : UserManager<TUser> where TUser : class
	{
		public ApplicationUserManager(IUserStore<TUser> store, 
			IOptions<IdentityOptions> optionsAccessor, 
			IPasswordHasher<TUser> passwordHasher, 
			IEnumerable<IUserValidator<TUser>> userValidators, 
			IEnumerable<IPasswordValidator<TUser>> passwordValidators, 
			ILookupNormalizer keyNormalizer, 
			IdentityErrorDescriber errors, 
			IServiceProvider services, 
			ILogger<ApplicationUserManager<TUser>> logger) 
			: base(
				store, 
				optionsAccessor, 
				passwordHasher, 
				userValidators, 
				passwordValidators, 
				keyNormalizer, 
				errors, 
				services, 
				logger)
		{
		}
	}
}
