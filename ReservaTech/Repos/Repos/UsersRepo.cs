using System.Linq;
using Data.Access;
using Entities.Core;
using Interfaces.Repos;

namespace Data.Repos
{
    public class UsersRepo : GenericRepository<ApplicationUser>,  IUsersRepo
    {
	    public UsersRepo(ApplicationDbContext context) : base(context)
	    {
	    }

	    public ApplicationUser GetById(string userId)
	    {
		    return GetAll().FirstOrDefault(a => a.Id == userId);
	    }
	}
}
