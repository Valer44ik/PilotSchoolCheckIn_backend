using PilotSchoolCheckIn.DatabaseTables;
using PilotSchoolCheckIn.Enums;
using PilotSchoolCheckIn.Models;

namespace PilotSchoolCheckIn.Services;

public interface IUserService 
{
	User?[] GetAllInstructors();
	
	User? GetById(long id);
	
	User? GetByEmail(string email);
	
	void PostUser(RegistrationModel user, UserRole role, DateTime createdAt, DateTime updatedAt, string program, DateOnly? birthYear, string hashedPassword);
}