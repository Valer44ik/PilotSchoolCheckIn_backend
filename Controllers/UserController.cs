using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
	
	public UserController(IUserService userService, IJwtAuthentication jwtAuthentication, IPasswordHasher passwordHasher, IHttpContextAccessor httpContextAccessor)
	{
		_userService = userService;
		_jwtAuthentication = jwtAuthentication;
		_passwordHasher = passwordHasher;
		_httpContext = httpContextAccessor.HttpContext;
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
	public IActionResult Login([FromQuery]string email, string password)
	{
		var user = _userService.GetByEmail(email);

		if (user == null)
		{
			return Unauthorized();
		}
		
		var result = _passwordHasher.VerifyHashedPassword(user.Password, password);

		if (result == false)
		{
			return Unauthorized();
		}
		
		var token = _jwtAuthentication.GenerateJwtToken(email);
		_httpContext.Response.Cookies.Append("jwtToken", token);
		
		return Ok(new { token });
	}
	
	[HttpGet]
	[Route("{id}")]
	[Authorize]
	public ActionResult<User> Get([FromRoute] long id)
	{
		var user = _userService.GetById(id);
		return user;
	}
	
	[HttpPost("register")]
	[AllowAnonymous]
	public ActionResult<UserModel> Register([FromBody] UserModel model)
	{
		if (!Enum.TryParse(model.Role, out UserRole role))
		{
			return BadRequest(ModelState);
		}
		
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		
		var existingUser = _userService.GetByEmail(model.Email);

		if (existingUser != null)
		{
			return Conflict("The user with the same email address already exists");
		}
		
		var hashedPassword = _passwordHasher.HashPassword(model.Password);
		
		_userService.PostUser(model, role, hashedPassword);
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