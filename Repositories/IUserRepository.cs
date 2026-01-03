using PilotSchoolCheckIn.DatabaseTables;

namespace PilotSchoolCheckIn.Repositories;

public interface IUserRepository
{
	User?[] GetAllInstructors();
	
	User? GetById(long id);
	
	User? GetByEmail(string email);
	
	void PostUser(User user);
}