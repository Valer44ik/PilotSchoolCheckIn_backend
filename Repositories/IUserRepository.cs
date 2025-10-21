using PilotSchoolCheckIn.DatabaseTables;

namespace PilotSchoolCheckIn.Repositories;

public interface IUserRepository
{
	User GetById(int id);
	
	void PostUser(User user);
}