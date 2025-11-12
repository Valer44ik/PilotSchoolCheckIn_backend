using PilotSchoolCheckIn.DatabaseTables;
using PilotSchoolCheckIn.Enums;
using PilotSchoolCheckIn.Models;

namespace PilotSchoolCheckIn.Services;

public interface IUserService 
{
	User GetById(long id);
	
	User? GetByEmailPassword(string email, string password);
	
	User? GetByEmail(string email);
	
	void PostUser(UserModel user, UserRole role, string hashedPassword);
}