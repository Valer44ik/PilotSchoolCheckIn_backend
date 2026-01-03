using PilotSchoolCheckIn.Contexts;
using PilotSchoolCheckIn.DatabaseTables;

namespace PilotSchoolCheckIn.Repositories;

public class FlightReservationRepository : IFlightReservationRepository
{
	private readonly PostgresDbContext _context;

	public FlightReservationRepository(PostgresDbContext context)
	{
		_context = context;
	}

	public FlightReservation? GetById(long id)
	{
		return _context.FlightReservations.Find(id);
	}

	public FlightReservation?[] GetOccupiedSlotsForWeek(DateTime startDate, DateTime endDate)
	{
		return _context.FlightReservations.Where(f => f.StartsAt >= startDate && f.EndsAt <= endDate).ToArray();
	}

	public FlightReservation?[] GetCalendarDatesForClient(long clientId)
	{
		return _context.FlightReservations.Where(f => f.ClientId == clientId).ToArray();
	}

	public FlightReservation?[] GetCalendarDatesForInstructor(long instructorId)
	{
		return _context.FlightReservations.Where(f => f.InstructorId == instructorId).ToArray();
	}

	public void CreateReservation(FlightReservation reservation)
	{
		_context.FlightReservations.Add(reservation);
		_context.SaveChanges();
	}

	public void UpdateReservation(FlightReservation flightReservation)
	{
		_context.FlightReservations.Update(flightReservation);
		_context.SaveChanges();
	}

	public void DeleteReservation(FlightReservation reservation)
	{
		_context.FlightReservations.Remove(reservation);
		_context.SaveChanges();
	}
}