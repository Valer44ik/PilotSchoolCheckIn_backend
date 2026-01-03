using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using PilotSchoolCheckIn.Enums;

namespace PilotSchoolCheckIn.DatabaseTables;

[Table("User")]
public sealed class User
{
	[Column("id")]
	[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public long Id { get; set; }
	
	[MaxLength(20)]
	public required string Name { get; set; }
	
	[MaxLength(20)]
	public required string Surname { get; set; }
	
	[MaxLength(3)]
	public string? Abbreviation { get; set; }
	
	[MaxLength(20)]
	public required string PhoneNumber { get; set; }
	
	public required string Password { get; set; }
	
	[MaxLength(50)]
	public required string Email { get; set; }
	
	[MaxLength(40)]
	public string? Nationality { get; set; }
	
	[MaxLength(10)]
	public string? Gender { get; set; }
	
	[MaxLength(40)]
	public string? Language { get; set; }
	public DateOnly? BirthYear { get; set; }
	
	[MaxLength(500)]
	public required string Program { get; set; }
	public required DateTime CreatedAt { get; set; }
	public required DateTime UpdatedAt { get; set; }
	public UserRole Role { get; set; }
	
	public ICollection<FlightReservation> ClientReservations { get; set; } = new List<FlightReservation>();
	public ICollection<FlightReservation> InstructorReservations { get; set; } = new List<FlightReservation>();
	
	public User() {}
	
	[SetsRequiredMembers]
	public User(long id, string name, string surname, string abbreviation, string phoneNumber, string password, string email, string? nationality, string? gender, string? language, DateOnly? birthYear, string program, DateTime createdAt, DateTime updatedAt, UserRole role)
	{
		Id = id;
		Name = name;
		Surname = surname;
		Abbreviation = abbreviation;
		PhoneNumber = phoneNumber;
		Password = password;
		Email = email;
		Nationality = nationality;
		Gender = gender;
		Language = language;
		BirthYear = birthYear;
		Program = program;
		CreatedAt = createdAt;
		UpdatedAt = updatedAt;
		Role = role;
	}
}