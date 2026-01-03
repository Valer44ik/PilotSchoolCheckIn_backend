using PilotSchoolCheckIn.DatabaseTables;
using PilotSchoolCheckIn.Enums;
using PilotSchoolCheckIn.Models;

namespace PilotSchoolCheckIn.Services;

public interface IFlightReservationService
{
	public FlightReservation? GetById(long id);
	
	public List<CalendarSlotModel> GetCalendarDatesForClient(long clientId, DateTime startDate, DateTime endDate);
	
	public List<CalendarSlotModel> GetCalendarDatesForInstructor(long instructorId, DateTime startDate, DateTime endDate);
	
	public void AddFlightReservation(FlightReservationModel flightReservation, FlightStatus status, DateTime createdAt, DateTime updatedAt);
	
	public void UpdateFlightReservation(long id, FlightStatus status, DateTime acceptedAt, DateTime updatedAt);
	
	public void DeleteFlightReservation(long id);

}