using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using PilotSchoolCheckIn.Enums;

namespace PilotSchoolCheckIn.DatabaseTables;

[Table("Plane")]
public sealed class Plane
{
	[Column("id")]
	[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public long Id { get; set; }
	
	[MaxLength(100)]
	public required string Model { get; set; }
	
	[MaxLength(20)]
	public required int BoardNumber { get; set; }
	
	public required DateTime CreatedAt { get; set; }
	
	public required DateTime UpdatedAt { get; set; }
	
	public EngineType EngineType { get; set; }
	
	[SetsRequiredMembers]
	public Plane(long id, string model, int boardNumber, DateTime createdAt, DateTime updatedAt, EngineType engineType)
	{
		Id = id;
		Model = model;
		BoardNumber = boardNumber;
		CreatedAt = createdAt;
		UpdatedAt = updatedAt;
		EngineType = engineType;
	}
}