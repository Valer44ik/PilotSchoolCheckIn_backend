using PilotSchoolCheckIn.DatabaseTables;
using PilotSchoolCheckIn.Enums;
using PilotSchoolCheckIn.Models;
using PilotSchoolCheckIn.Repositories;

namespace PilotSchoolCheckIn.Services;

public class FlightReservationService : IFlightReservationService
{
	private IFlightReservationRepository _flightReservationRepository;
	private IUserRepository _userRepository;

	public FlightReservationService(IFlightReservationRepository flightReservationRepository, IUserRepository userRepository)
	{
		_flightReservationRepository = flightReservationRepository;
		_userRepository = userRepository;
	}

	public FlightReservation? GetById(long id)
	{
		return _flightReservationRepository.GetById(id);
	}

	public List<CalendarSlotModel> GetCalendarDatesForClient(long clientId,  DateTime startDate, DateTime endDate)
	{
		var currentWeekDates = _flightReservationRepository.GetOccupiedSlotsForWeek(startDate, endDate);

		var occupierReservations = new List<CalendarSlotModel>();

		if (currentWeekDates != Array.Empty<FlightReservation>())
		{
			foreach (var currentWeekDate in currentWeekDates)
			{
				if (currentWeekDate!.ClientId == clientId)
				{
					occupierReservations.Add(new CalendarSlotModel
					{
						Id = currentWeekDate.Id,
						Start = currentWeekDate.StartsAt,
						End = currentWeekDate.EndsAt,
						Description = currentWeekDate.Status.ToString(),
						InstructorAbbreviation =
							_userRepository.GetById(currentWeekDate.InstructorId)!.Abbreviation,
						ClientSurname = _userRepository.GetById(currentWeekDate.ClientId)!.Surname,
					});
				}
				else
				{
					occupierReservations.Add( new CalendarSlotModel
					{
						Id = currentWeekDate.Id,
						Start = currentWeekDate.StartsAt,
						End = currentWeekDate.EndsAt,
						Description = "Occupied by other client",
						InstructorAbbreviation = _userRepository.GetById(currentWeekDate.InstructorId)!.Abbreviation,
						ClientSurname = _userRepository.GetById(currentWeekDate.ClientId)!.Surname,
					});
				}
			}
		}
		
		return occupierReservations;
	}

	public List<CalendarSlotModel> GetCalendarDatesForInstructor(long instructorId,  DateTime startDate, DateTime endDate)
	{
		var currentWeekDates = _flightReservationRepository.GetOccupiedSlotsForWeek(startDate, endDate);

		var occupierReservations = new List<CalendarSlotModel>();
		
		if (currentWeekDates != Array.Empty<FlightReservation>())
		{
			foreach (var currentWeekDate in currentWeekDates)
			{
				if (currentWeekDate!.InstructorId == instructorId)
				{
					occupierReservations.Add( new CalendarSlotModel
						{
							Id = currentWeekDate.Id,
							Start = currentWeekDate.StartsAt, 
							End = currentWeekDate.EndsAt, 
							Description = currentWeekDate.Status.ToString(),
							InstructorAbbreviation = _userRepository.GetById(currentWeekDate.InstructorId)!.Abbreviation,
							ClientSurname = _userRepository.GetById(currentWeekDate.ClientId)!.Surname,
						});
				}
			}
		}
		
		return occupierReservations;
	}

	public void AddFlightReservation(FlightReservationModel model, FlightStatus status, DateTime createdAt, DateTime updatedAt)
	{
		var startsAt = DateTime.SpecifyKind(
			DateTimeOffset.FromUnixTimeSeconds(long.Parse(model.StartsAt)).DateTime,
			DateTimeKind.Utc
		);

		var endsAt = DateTime.SpecifyKind(
			DateTimeOffset.FromUnixTimeSeconds(long.Parse(model.EndsAt)).DateTime,
			DateTimeKind.Utc
		);
		
		var reservation = new FlightReservation(model.Id, model.ClientId, model.InstructorId, model.PlaneId, startsAt, endsAt, model.Note,
			createdAt, updatedAt, status);
		
		_flightReservationRepository.CreateReservation(reservation);
	}

	public void UpdateFlightReservation(long id, FlightStatus status, DateTime acceptedAt, DateTime updatedAt)
	{
		var flightReservation = _flightReservationRepository.GetById(id);
		
		flightReservation!.Status = status;
		flightReservation.AcceptedAt = acceptedAt;
		flightReservation.UpdatedAt = updatedAt;
		
		_flightReservationRepository.UpdateReservation(flightReservation);
	}

	public void DeleteFlightReservation(long id)
	{
		var flightReservation = _flightReservationRepository.GetById(id);
		
		_flightReservationRepository.DeleteReservation(flightReservation);
	}
}