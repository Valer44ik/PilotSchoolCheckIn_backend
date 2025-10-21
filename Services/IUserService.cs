using PilotSchoolCheckIn.DatabaseTables;
using PilotSchoolCheckIn.Models;

namespace PilotSchoolCheckIn.Services;

public interface IUserService 
{
	User GetById(long id);
	
	void PostUser(UserModel user);
}