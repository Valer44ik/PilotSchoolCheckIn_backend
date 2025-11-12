using PilotSchoolCheckIn.DatabaseTables;

namespace PilotSchoolCheckIn.Repositories;

public interface IUserRepository
{
	User? GetByEmailPassword(string email, string password);
	
	User? GetById(long id);
	
	User? GetByEmail(string email);
	
	void PostUser(User user);
}