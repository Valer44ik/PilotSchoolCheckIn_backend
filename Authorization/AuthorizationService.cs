// using System.Security.Claims;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.Extensions.Options;
// using PilotSchoolCheckIn.Authentication;
//
// namespace PilotSchoolCheckIn.Authorization;
//
// public class AuthorizationService
// {
// 	private readonly AuthorizationOptions _options;
//
// 	public AuthorizationService(IOptions<AuthorizationOptions> options)
// 	{
// 		_options = options.Value;
// 	}
//
// 	public bool HasPermission(string role, string permission)
// 	{
// 		var rolePerm = _options.RolePermissions
// 			.FirstOrDefault(r => r.Role == role);
//
// 		return rolePerm?.Permissions.Contains(permission) ?? false;
// 	}
//
// 	// public Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object? resource, IEnumerable<IAuthorizationRequirement> requirements)
// 	// {
// 	// 	throw new NotImplementedException();
// 	// }
// 	//
// 	// public Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object? resource, string policyName)
// 	// {
// 	// 	throw new NotImplementedException();
// 	// }
// }