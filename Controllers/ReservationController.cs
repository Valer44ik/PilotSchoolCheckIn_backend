using Microsoft.AspNetCore.Mvc;
using PilotSchoolCheckIn.DatabaseTables;
using PilotSchoolCheckIn.Enums;
using PilotSchoolCheckIn.Models;
using PilotSchoolCheckIn.Services;

namespace PilotSchoolCheckIn.Controllers;

public class ReservationController : Controller
{
	private readonly IUserService _userService;
	private readonly IPlaneService _planeService;
	private readonly IFlightReservationService _flightReservationService;

	public ReservationController(IUserService userService, IPlaneService planeService, IFlightReservationService flightReservationService)
	{
		_userService = userService;
		_planeService = planeService;
		_flightReservationService = flightReservationService;
	}
	
	[HttpGet]
	[Route("{id}")]
	public ActionResult<FlightReservation> Get([FromRoute] long id)
	{
		var reservation = _flightReservationService.GetById(id);
		return reservation;
	}
	
	// [HttpGet]
	// [Route("instructors")]
	// public ActionResult<FlightReservation> GetAllInstructors()
	// {
	// 	var instructorsList = _userService.
	// 	return reservation;
	// }
	
	[HttpPost]
	[Route("reservation")]
	public ActionResult<FlightReservationModel> CreateReservation([FromBody] FlightReservationModel model)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		
		var client = _userService.GetById(model.ClientId);
		if (client == null || client.Role != UserRole.Client)
		{
			return BadRequest("Appropriate client is not provided");
		}
		
		var instructor = _userService.GetById(model.InstructorId);
		if (instructor == null || instructor.Role != UserRole.Instructor)
		{
			return BadRequest("Appropriate instructor is not provided");
		}
		
		var plane = _planeService.GetById(model.PlaneId);
		if (plane == null)
		{
			return BadRequest("Plane is not provided");
		}
		
		var status = FlightStatus.Pending;
		
		_flightReservationService.AddFlightReservation(model, status, DateTime.UtcNow, DateTime.UtcNow);
		return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
	}
}