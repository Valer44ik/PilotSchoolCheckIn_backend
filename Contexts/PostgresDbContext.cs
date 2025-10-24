using Microsoft.EntityFrameworkCore;
using PilotSchoolCheckIn.DatabaseTables;
using PilotSchoolCheckIn.Models;

namespace PilotSchoolCheckIn.Contexts;

public class PostgresDbContext : DbContext
{
	public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }
	
	public DbSet<User> Users { get; set; }
	
	public DbSet<Plane>  Planes { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<User>().ToTable("User");
		modelBuilder.Entity<User>().HasKey(x => x.Id);
		modelBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();
		modelBuilder.Entity<User>()
			.HasIndex(p => new { p.PhoneNumber, p.Email })
			.IsUnique();
		
		modelBuilder.Entity<Plane>().ToTable("Plane");
		modelBuilder.Entity<Plane>().HasKey(x => x.Id);
		modelBuilder.Entity<Plane>().Property(x => x.Id).ValueGeneratedOnAdd();
		modelBuilder.Entity<Plane>()
			.HasIndex(p => new { p.BoardNumber })
			.IsUnique();
	}
}