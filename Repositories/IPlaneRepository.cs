using PilotSchoolCheckIn.DatabaseTables;

namespace PilotSchoolCheckIn.Repositories;

public interface IPlaneRepository
{
	Plane GetById(long id);
	
	Plane?[] GetAllPlanes();
	
	void PostPlane(Plane user);
}