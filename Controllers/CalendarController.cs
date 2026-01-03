using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using PilotSchoolCheckIn.Enums;
using PilotSchoolCheckIn.Services;

namespace PilotSchoolCheckIn.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CalendarController : ControllerBase
{
	private readonly IUserService _userService;
	private readonly IFlightReservationService _flightReservationService;

	public CalendarController(IUserService userService, IFlightReservationService flightReservationService)
	{
		_userService = userService;
		_flightReservationService = flightReservationService;
	}

	[HttpGet]
	[Route("")]
	public IActionResult OpenCalendar([FromQuery] string token)
	{
		var handler = new JwtSecurityTokenHandler();

		var jsonToken = handler.ReadJwtToken(token);

		var userId = jsonToken.Claims.First().Value;
		
		var user = _userService.GetById(long.Parse(userId));

		if (user == null)
		{
			return NotFound();
		}
		
		return Ok(new { userRole = user.Role });
	}
	
	[HttpGet]
	[Route("dates")]
	public IActionResult GetCalendarDatesForClient([FromQuery] string startDate, string endDate, string clientId)
	{
		var user = _userService.GetById(long.Parse(clientId));

		if (user == null)
		{
			return NotFound();
		}
		
		var startsAt = DateTime.SpecifyKind(
			DateTimeOffset.FromUnixTimeSeconds(long.Parse(startDate)).DateTime,
			DateTimeKind.Utc
		);

		var endsAt = DateTime.SpecifyKind(
			DateTimeOffset.FromUnixTimeSeconds(long.Parse(endDate)).DateTime,
			DateTimeKind.Utc
		);
		
		if (user.Role == UserRole.Client)
		{
			var reservations = _flightReservationService.GetCalendarDatesForClient(user.Id, startsAt, endsAt);
			return Ok(reservations);
		}
		else
		{
			var reservations = _flightReservationService.GetCalendarDatesForInstructor(user.Id, startsAt, endsAt);
			return Ok(reservations);
		}
	}
}