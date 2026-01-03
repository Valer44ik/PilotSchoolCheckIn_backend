using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PilotSchoolCheckIn.Enums;

namespace PilotSchoolCheckIn.Authentication;

public class JwtAuthentication : IJwtAuthentication
{
	private readonly JwtOptions _jwtOptions;
	
	public JwtAuthentication(IOptions<JwtOptions> jwtOptions)
	{
		_jwtOptions = jwtOptions.Value;
	}
	
	public string GenerateJwtToken(long id, string name, string surname, string email, UserRole role)
	{
		Claim[] claims = 
		[
			new("Id", id.ToString()),
			new("name", name),
			new("surname", surname),
			new("email", email),
			new("role", role.ToString())
		];
		
		var signingCredentials = new SigningCredentials(
			new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey))
			, SecurityAlgorithms.HmacSha256);

		var token = new JwtSecurityToken(
			signingCredentials: signingCredentials,
			claims: claims,
			expires: DateTime.UtcNow.AddHours(_jwtOptions.ExpiresHours));
		
		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}