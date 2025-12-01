namespace PilotSchoolCheckIn.Authentication;

public interface IJwtAuthentication
{
	public string GenerateJwtToken(long id);
}