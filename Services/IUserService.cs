using PilotSchoolCheckIn.DatabaseTables;
using PilotSchoolCheckIn.Enums;
using PilotSchoolCheckIn.Models;

namespace PilotSchoolCheckIn.Services;

public interface IUserService 
{
	User GetById(int id);
	
	void PostUser(UserModel user, UserRole role);
}