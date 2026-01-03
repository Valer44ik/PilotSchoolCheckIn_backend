using PilotSchoolCheckIn.Contexts;
using PilotSchoolCheckIn.DatabaseTables;

namespace PilotSchoolCheckIn.Repositories;

public class PlaneRepository : IPlaneRepository
{
	private readonly PostgresDbContext _context;

	public PlaneRepository(PostgresDbContext context)
	{
		_context = context;
	}
	
	public Plane GetById(long id)
	{
		return _context.Planes.Find(id);
	}

	public Plane?[] GetAllPlanes()
	{
		return _context.Planes.ToArray();
	}

	public void PostPlane(Plane plane)
	{
		_context.Planes.Add(plane);
		_context.SaveChanges();
	}
}