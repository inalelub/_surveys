using _surveys.Models;
using Microsoft.EntityFrameworkCore;

namespace _surveys.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		
		public DbSet<Survey> Surveys { get; set; }
	}
}
