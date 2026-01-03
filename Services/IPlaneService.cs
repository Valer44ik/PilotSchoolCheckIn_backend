using PilotSchoolCheckIn.DatabaseTables;
using PilotSchoolCheckIn.Enums;
using PilotSchoolCheckIn.Models;

namespace PilotSchoolCheckIn.Services;

public interface IPlaneService
{
	Plane? GetById(long id);
	
	Plane?[] GetAllPlanes();
	
	void PostPlane(PlaneModel model, EngineType engineType);
}