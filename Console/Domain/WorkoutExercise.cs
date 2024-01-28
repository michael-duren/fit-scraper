using System.ComponentModel.DataAnnotations.Schema;

namespace Console.Domain;

public class WorkoutExercise
{
    public int WorkoutExerciseId { get; set; }
    [ForeignKey("WorkoutId")] public int WorkoutId { get; set; }
    [ForeignKey("ExerciseId")] public int ExerciseId { get; set; }
}