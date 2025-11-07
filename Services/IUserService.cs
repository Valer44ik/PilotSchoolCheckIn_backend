using PilotSchoolCheckIn.DatabaseTables;
using PilotSchoolCheckIn.Enums;
using PilotSchoolCheckIn.Models;

namespace PilotSchoolCheckIn.Services;

public interface IUserService 
{
	User GetById(long id);
	
	User? GetByEmailPassword(string email, string password);
	
	void PostUser(UserModel user, UserRole role);
}