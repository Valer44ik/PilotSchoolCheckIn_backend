using PilotSchoolCheckIn.DatabaseTables;

namespace PilotSchoolCheckIn.Repositories;

public interface IUserRepository
{
	User GetById(long id);
	
	void PostUser(User user);
}