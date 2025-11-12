namespace PilotSchoolCheckIn.Authentication;

public interface IJwtAuthentication
{
	public string GenerateJwtToken(string email);
}