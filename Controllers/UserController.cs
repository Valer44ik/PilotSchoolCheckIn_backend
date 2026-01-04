using System.Globalization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PilotSchoolCheckIn.Authentication;
using PilotSchoolCheckIn.DatabaseTables;
using PilotSchoolCheckIn.Enums;
using PilotSchoolCheckIn.Models;
using PilotSchoolCheckIn.Services;

namespace PilotSchoolCheckIn.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
	private readonly IUserService _userService;
	private readonly IPasswordHasher _passwordHasher;
	private readonly IJwtAuthentication _jwtAuthentication;
	private readonly HttpContext _httpContext;
	private readonly JwtOptions _jwtOptions;
	
	public UserController(IUserService userService, IJwtAuthentication jwtAuthentication, IPasswordHasher passwordHasher, IHttpContextAccessor httpContextAccessor, IOptions<JwtOptions> jwtOptions)
	{
		_userService = userService;
		_jwtAuthentication = jwtAuthentication;
		_passwordHasher = passwordHasher;
		_jwtOptions = jwtOptions.Value;
		_httpContext = httpContextAccessor.HttpContext!;
	}

	[HttpGet]
	[Route("email")]
	[AllowAnonymous]
	public IActionResult GetByEmail([FromQuery]string email)
	{
		var user = _userService.GetByEmail(email);

		if (user != null)
		{
			return Conflict(new { exists = true, email = email });
		}
		
		return Ok(new { exists = false, email = email });
	}
	
	[HttpPost]
	[Route("login")]
	[AllowAnonymous]
	public IActionResult Login([FromBody]LoginModel model)
	{
		var user = _userService.GetByEmail(model.Email);

		if (user == null)
		{
			return Unauthorized("User not found");
		}
		
		var result = _passwordHasher.VerifyHashedPassword(user.Password, model.Password);

		if (result == false)
		{
			return Unauthorized("Invalid password");
		}
		
		var token = _jwtAuthentication.GenerateJwtToken(user.Id, user.Name, user.Surname,  user.Email, user.Role);
		_httpContext.Response.Cookies.Append("jwtToken", token);
		
		return Ok(new { token, user.Id , expirationDate = DateTimeOffset.UtcNow.AddHours(_jwtOptions.ExpiresHours).ToUnixTimeSeconds() });
	}
	
	[HttpGet]
	[Route("{id}")]
	[Authorize]
	public ActionResult<User> Get([FromRoute] long id)
	{
		var user = _userService.GetById(id);
		return user;
	}
	
	[HttpGet]
	[Route("")]
	[Authorize]
	public ActionResult<User> GetById([FromQuery] long id)
	{
		var user = _userService.GetById(id);
		return user;
	}
	
	[HttpPost("register")]
	[AllowAnonymous]
	public ActionResult<RegistrationModel> Register([FromBody] RegistrationModel model)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		
		var existingUser = _userService.GetByEmail(model.Email);

		if (existingUser != null)
		{
			return Conflict("The user with the same email address already exists");
		}
		
		DateOnly.TryParseExact(
			model.BirthYear,
			"dd / MM / yyyy",
			CultureInfo.InvariantCulture,
			DateTimeStyles.None,
			out var birthYear
		);
		
		var hashedPassword = _passwordHasher.HashPassword(model.Password);
		
		model.Abbreviation = model.Name.Substring(0, 1) + model.Surname.Substring(0, 2).ToUpper();
		
		_userService.PostUser(model, UserRole.Guest, DateTime.UtcNow, DateTime.UtcNow, "Undefined", birthYear, hashedPassword);
		return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
	}
	
	// test method
	[HttpGet]
	[Authorize]
	[Route("hello_world")] 
	public ActionResult<string> HelloWorld()
	{
		return Content("HelloWorld");
	}
}