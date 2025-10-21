using PilotSchoolCheckIn.Enums;

namespace PilotSchoolCheckIn.Models;

public class UserModel
{
	public int Id { get; set; }
	public required string Name { get; set; }
	public required string Surname { get; set; }
	public required string PhoneNumber { get; set; }
	public required string Password { get; set; }
	public required string Email { get; set; }
	public string Nationality { get; set; }
	public string Gender { get; set; }
	public string Language { get; set; }
	public UInt32 Age { get; set; }
	public required string Program { get; set; }
	public required DateTime CreatedAt { get; set; }
	public required DateTime UpdatedAt { get; set; }
	public UserRole Role { get; set; }
}