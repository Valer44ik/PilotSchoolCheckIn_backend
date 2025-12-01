using PilotSchoolCheckIn.DatabaseTables;
using PilotSchoolCheckIn.Enums;
using PilotSchoolCheckIn.Models;
using PilotSchoolCheckIn.Repositories;

namespace PilotSchoolCheckIn.Services;

public class FlightReservationService : IFlightReservationService
{
	private IFlightReservationRepository _flightReservationRepository;

	public FlightReservationService(IFlightReservationRepository flightReservationRepository)
	{
		_flightReservationRepository = flightReservationRepository;
	}

	public FlightReservation? GetById(long id)
	{
		return _flightReservationRepository.GetById(id);
	}

	public FlightReservation?[] GetCalendarDatesForClient(long clientId)
	{
		return _flightReservationRepository.GetCalendarDatesForClient(clientId);
	}

	public FlightReservation?[] GetCalendarDatesForInstructor(long instructorId)
	{
		return _flightReservationRepository.GetCalendarDatesForInstructor(instructorId);
	}

	public void AddFlightReservation(FlightReservationModel model, FlightStatus status, DateTime createdAt, DateTime updatedAt)
	{
		var reservation = new FlightReservation(model.Id, model.ClientId, model.InstructorId, model.PlaneId, model.StartsAt, model.EndsAt, model.Note,
			createdAt, updatedAt, status);
		
		_flightReservationRepository.CreateReservation(reservation);
	}
}