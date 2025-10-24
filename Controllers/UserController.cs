using Microsoft.AspNetCore.Mvc;
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
	
	public UserController(IUserService userService)
	{
		_userService = userService;
	}

	[HttpGet]
	[Route("{id}")]
	public ActionResult<User> Get([FromRoute] long id)
	{
		var user = _userService.GetById(id);
		return user;
	}

	[HttpPost("register")]
	public ActionResult<UserModel> Post([FromBody] UserModel model)
	{
		if (!Enum.TryParse(model.Role, out UserRole role))
		{
			return BadRequest(ModelState);
		}
		
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		
		_userService.PostUser(model, role);
		return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
	}
	
	// test method
	[HttpGet]
	[Route("hello_world")]
	public ActionResult<string> HelloWorld()
	{
		return Content("HelloWorld");
	}
}