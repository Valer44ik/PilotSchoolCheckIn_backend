using Microsoft.EntityFrameworkCore;
using PilotSchoolCheckIn.DatabaseTables;

namespace PilotSchoolCheckIn.Contexts;

public class PostgresDbContext : DbContext
{
	public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }
	
	public DbSet<User> Users { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<User>().ToTable("User");
		modelBuilder.Entity<User>().HasKey(x => x.Id);
		modelBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();
	}
}