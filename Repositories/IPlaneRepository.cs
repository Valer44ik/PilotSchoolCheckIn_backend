using PilotSchoolCheckIn.DatabaseTables;

namespace PilotSchoolCheckIn.Repositories;

public interface IPlaneRepository
{
	Plane GetById(long id);
	
	void PostPlane(Plane user);
}