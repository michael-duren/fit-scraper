using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.Domain;

public class Workout
{
    [Key] public int WorkoutId { get; set; }
    [Column(TypeName = "varchar(100)")] public string? Name { get; init; }
}