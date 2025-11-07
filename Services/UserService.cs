using PilotSchoolCheckIn.DatabaseTables;
using PilotSchoolCheckIn.Enums;
using PilotSchoolCheckIn.Models;
using PilotSchoolCheckIn.Repositories;

namespace PilotSchoolCheckIn.Services;

public class UserService : IUserService
{
	private readonly IUserRepository _userRepository;

	public UserService(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public User GetById(long id)
	{
		return _userRepository.GetById(id);
	}

	public User? GetByEmailPassword(string email, string password)
	{
		return _userRepository.GetByEmailPassword(email, password);
	}

	public void PostUser(UserModel model, UserRole role)
	{
		var user = new User(model.Id, model.Name, model.Surname, model.PhoneNumber, model.Password, model.Email, model.Nationality,
			model.Gender, model.Language, model.BirthYear, model.Program, model.CreatedAt, model.UpdatedAt, role);
		
		_userRepository.PostUser(user);
	}
}