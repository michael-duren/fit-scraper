using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.Domain;

public class WorkoutType
{
    [Key] public int WorkoutTypeId { get; set; }
    [Column(TypeName = "varchar(100)")] public string WorkoutTypeName { get; set; } = null!;
}