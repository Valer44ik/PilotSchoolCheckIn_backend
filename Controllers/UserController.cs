using Microsoft.AspNetCore.Mvc;
using PilotSchoolCheckIn.DatabaseTables;
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
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		
		_userService.PostUser(model);
		return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
	}
}