using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repos
{
    public class ReservaTechDbContext : IdentityDbContext
    {
        public ReservaTechDbContext(DbContextOptions<ReservaTechDbContext> options)
            : base(options)
        {

        }
    }
}
