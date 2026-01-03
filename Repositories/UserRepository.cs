using PilotSchoolCheckIn.Contexts;
using PilotSchoolCheckIn.DatabaseTables;
using PilotSchoolCheckIn.Enums;

namespace PilotSchoolCheckIn.Repositories;

public class UserRepository : IUserRepository
{
	private readonly PostgresDbContext _context;

	public UserRepository(PostgresDbContext context)
	{
		_context = context;
	}

	public User?[] GetAllInstructors()
	{
		return _context.Users.Where(f => f.Role == UserRole.Instructor).ToArray();
	}

	public User? GetById(long id)
	{
		return _context.Users.Find(id);
	}

	public User? GetByEmail(string email)
	{
		return _context.Users.FirstOrDefault(u => u.Email == email);
	}

	public void PostUser(User user)
	{
		_context.Users.Add(user);
		_context.SaveChanges();
	}
}