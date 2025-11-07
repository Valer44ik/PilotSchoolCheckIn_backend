using PilotSchoolCheckIn.DatabaseTables;

namespace PilotSchoolCheckIn.Repositories;

public interface IUserRepository
{
	User? GetByEmailPassword(string email, string password);
	
	User GetById(long id);
	
	void PostUser(User user);
}