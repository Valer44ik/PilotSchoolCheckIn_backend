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
	public int Id { get; set; }
	
	[MaxLength(20)]
	public required string Name { get; set; }
	
	[MaxLength(20)]
	public required string Surname { get; set; }
	
	[MaxLength(20)]
	public required string PhoneNumber { get; set; }
	
	[MaxLength(20)]
	public required string Password { get; set; }
	
	[MaxLength(50)]
	public required string Email { get; set; }
	
	[MaxLength(40)]
	public string Nationality { get; set; }
	
	[MaxLength(10)]
	public string Gender { get; set; }
	
	[MaxLength(40)]
	public string Language { get; set; }
	public UInt32 Age { get; set; }
	
	[MaxLength(500)]
	public required string Program { get; set; }
	public required DateTime CreatedAt { get; set; }
	public required DateTime UpdatedAt { get; set; }
	public UserRole Role { get; set; }
	
	[SetsRequiredMembers]
	public User(int id, string name, string surname, string phoneNumber, string password, string email, string nationality, string gender, string language, uint age, string program, DateTime createdAt, DateTime updatedAt, UserRole role)
	{
		Id = id;
		Name = name;
		Surname = surname;
		PhoneNumber = phoneNumber;
		Password = password;
		Email = email;
		Nationality = nationality;
		Gender = gender;
		Language = language;
		Age = age;
		Program = program;
		CreatedAt = createdAt;
		UpdatedAt = updatedAt;
		Role = role;
	}
}