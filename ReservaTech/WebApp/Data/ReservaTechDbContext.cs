using Entities.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Data
{
    public class ReservaTechDbContext : IdentityDbContext<AppUser>
    {
        public ReservaTechDbContext(DbContextOptions<ReservaTechDbContext> options)
            : base(options)
        {

        }
    }
}
