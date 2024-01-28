using System.ComponentModel.DataAnnotations.Schema;

namespace Console.Domain;

public class Workout
{
    public int WorkoutId { get; set; }
    [Column(TypeName = "varchar(100)")] public string? Name { get; set; }
}