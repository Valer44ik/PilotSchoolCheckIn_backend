using PilotSchoolCheckIn.Contexts;
using PilotSchoolCheckIn.DatabaseTables;
using PilotSchoolCheckIn.Services;

namespace PilotSchoolCheckIn.Repositories;

public class UserRepository : IUserRepository
{
	private readonly PostgresDbContext _context;

	public UserRepository(PostgresDbContext context)
	{
		_context = context;
	}

	public User? GetByEmailPassword(string email, string password)
	{
		return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
	}

	public User GetById(long id)
	{
		return _context.Users.Find(id);
	}

	public void PostUser(User user)
	{
		_context.Users.Add(user);
		_context.SaveChanges();
	}
}