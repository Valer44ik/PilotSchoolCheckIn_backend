using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace PilotSchoolCheckIn.Authentication;

public class JwtAuthentication : IJwtAuthentication
{
	// public string GenerateJwtToken(string email)
	// {
	// 	var claims = new[]
	// 	{
	// 		new Claim(JwtRegisteredClaimNames.Sub, email),
	// 		new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
	// 	};
	//
	// 	var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_super_secret_key"));
	// 	var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
	//
	// 	var token = new JwtSecurityToken(
	// 		issuer: "yourdomain.com",
	// 		audience: "yourdomain.com",
	// 		claims: claims,
	// 		expires: DateTime.Now.AddMinutes(30),
	// 		signingCredentials: creds);
	//
	// 	return new JwtSecurityTokenHandler().WriteToken(token);
	// }

	private readonly JwtOptions _jwtOptions;
	
	public JwtAuthentication(IOptions<JwtOptions> jwtOptions)
	{
		_jwtOptions = jwtOptions.Value;
	}
	
	public string GenerateJwtToken(string email)
	{
		Claim[] claims = [new("Email", email)];
		
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