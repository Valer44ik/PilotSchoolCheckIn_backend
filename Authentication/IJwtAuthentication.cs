using PilotSchoolCheckIn.Enums;

namespace PilotSchoolCheckIn.Authentication;

public interface IJwtAuthentication
{
	public string GenerateJwtToken(long id, string name, string surname, string email, UserRole role);
}