using Entities.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Access
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		private DbSet<Business> Businesses { get; set; }
		private DbSet<Appointment> Appointments { get; set; }
		private DbSet<BusinessRules> BusinessRules { get; set; }
		private DbSet<DailySchedule> DailySchedules { get; set; }
		private DbSet<License> Licenses { get; set; }
		private DbSet<Unit> Units { get; set; }
	}
}
