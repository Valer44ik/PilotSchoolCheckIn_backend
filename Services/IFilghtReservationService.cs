using PilotSchoolCheckIn.DatabaseTables;
using PilotSchoolCheckIn.Enums;
using PilotSchoolCheckIn.Models;

namespace PilotSchoolCheckIn.Services;

public interface IFlightReservationService
{
	public FlightReservation? GetById(long id);
	
	public FlightReservation?[] GetCalendarDatesForClient(long clientId);
	
	public FlightReservation?[] GetCalendarDatesForInstructor(long instructorId);
	
	public void AddFlightReservation(FlightReservationModel flightReservation, FlightStatus status, DateTime createdAt, DateTime updatedAt);
}