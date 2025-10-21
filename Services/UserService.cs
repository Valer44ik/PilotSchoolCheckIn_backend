using PilotSchoolCheckIn.DatabaseTables;
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

	public void PostUser(UserModel model)
	{
		var user = new User(model.Id, model.Name, model.Surname, model.PhoneNumber, model.Password, model.Email, model.Nationality,
			model.Gender, model.Language, model.Age, model.Program, model.CreatedAt, model.UpdatedAt, model.Role);
		
		_userRepository.PostUser(user);
	}
}