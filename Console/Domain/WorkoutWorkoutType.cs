using System.ComponentModel.DataAnnotations.Schema;

namespace Console.Domain;

public class WorkoutWorkoutType
{
    public int WorkoutWorkoutTypeId { get; set; }
    [ForeignKey("WorkoutId")] public int WorkoutId { get; set; }
    [ForeignKey("WorkoutTypeId")] public int WorkoutTypeId { get; set; }
}