using PilotSchoolCheckIn.DatabaseTables;
using PilotSchoolCheckIn.Enums;
using PilotSchoolCheckIn.Models;
using PilotSchoolCheckIn.Repositories;

namespace PilotSchoolCheckIn.Services;

public class PlaneService : IPlaneService
{
	private readonly IPlaneRepository _planeRepository;

	public PlaneService(IPlaneRepository planeRepository)
	{
		_planeRepository = planeRepository;
	}
	
	public Plane? GetById(long id)
	{
		return _planeRepository.GetById(id);
	}

	public Plane?[] GetAllPlanes()
	{
		return _planeRepository.GetAllPlanes();
	}

	public void PostPlane(PlaneModel model, EngineType engineType)
	{
		var plane = new Plane(model.Id, model.Model, model.BoardNumber, model.CreatedAt, model.UpdatedAt, engineType);
		
		_planeRepository.PostPlane(plane);
	}
}