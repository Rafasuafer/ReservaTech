using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Core;

namespace Interfaces.Repos
{
	public interface IUsersRepo: IGenericRepository<ApplicationUser>
	{
		ApplicationUser GetById(string userId);
	}
}
