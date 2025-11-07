using Microsoft.EntityFrameworkCore;
using PilotSchoolCheckIn.DatabaseTables;
using PilotSchoolCheckIn.Models;

namespace PilotSchoolCheckIn.Contexts;

public class PostgresDbContext : DbContext
{
	public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }
	
	public DbSet<User> Users { get; set; }
	
	public DbSet<Plane>  Planes { get; set; }
	
	public DbSet<FlightReservation> FlightReservations { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<User>().ToTable("User");
		modelBuilder.Entity<User>().HasKey(u => u.Id);
		modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();
		modelBuilder.Entity<User>()
			.HasIndex(u => new { u.PhoneNumber, u.Email })
			.IsUnique();
		
		modelBuilder.Entity<Plane>().ToTable("Plane");
		modelBuilder.Entity<Plane>().HasKey(p => p.Id);
		modelBuilder.Entity<Plane>().Property(p => p.Id).ValueGeneratedOnAdd();
		modelBuilder.Entity<Plane>()
			.HasIndex(p => new { p.BoardNumber })
			.IsUnique();
		
		modelBuilder.Entity<FlightReservation>().ToTable("FlightReservation");
		modelBuilder.Entity<FlightReservation>().HasKey(fr => fr.Id);
		modelBuilder.Entity<FlightReservation>().Property(fr => fr.Id).ValueGeneratedOnAdd();
		modelBuilder.Entity<FlightReservation>().HasOne(fr => fr.User)
			.WithOne(u => u.FlightReservation)
			.HasForeignKey<FlightReservation>(fr => fr.ClientId)
			.HasPrincipalKey<User>(u => u.Id);
		modelBuilder.Entity<FlightReservation>().HasOne(fr => fr.User)
			.WithOne(u => u.FlightReservation)
			.HasForeignKey<FlightReservation>(fr => fr.InstructorId)
			.HasPrincipalKey<User>(u => u.Id);
		modelBuilder.Entity<FlightReservation>().HasOne(fr => fr.Plane)
			.WithOne(p => p.FlightReservation)
			.HasForeignKey<FlightReservation>(fr => fr.PlaneId)
			.HasPrincipalKey<Plane>(p => p.Id);
	}
}