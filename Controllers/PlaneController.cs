using Microsoft.AspNetCore.Mvc;
using PilotSchoolCheckIn.Services;

namespace PilotSchoolCheckIn.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlaneController
{
	private readonly IPlaneService _planeService;
	
	public PlaneController(IPlaneService planeService)
	{
		_planeService = planeService;
	}
}