using PilotSchoolCheckIn.DatabaseTables;

namespace PilotSchoolCheckIn.Repositories;

public interface IFlightReservationRepository
{
	public FlightReservation? GetById(long id);
	
	public FlightReservation?[] GetOccupiedSlotsForWeek(DateTime startDate, DateTime endDate);
	
	public FlightReservation?[] GetCalendarDatesForClient(long clientId);

	public FlightReservation?[] GetCalendarDatesForInstructor(long instructorId);
	
	public void CreateReservation(FlightReservation reservation);
	
	public void UpdateReservation(FlightReservation flightReservation);
	
	public void DeleteReservation(FlightReservation reservation);
}