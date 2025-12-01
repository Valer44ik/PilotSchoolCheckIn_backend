using PilotSchoolCheckIn.DatabaseTables;

namespace PilotSchoolCheckIn.Repositories;

public interface IFlightReservationRepository
{
	public FlightReservation? GetById(long id);
	
	public FlightReservation?[] GetCalendarDatesForClient(long clientId);

	public FlightReservation?[] GetCalendarDatesForInstructor(long instructorId);
	
	public void CreateReservation(FlightReservation reservation);
}