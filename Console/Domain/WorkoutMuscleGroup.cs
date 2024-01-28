using System.ComponentModel.DataAnnotations.Schema;

namespace Console.Domain;

public class WorkoutMuscleGroup
{
    public int WorkoutMuscleGroupId { get; set; }
    [ForeignKey("WorkoutId")] public int WorkoutId { get; set; }
    [ForeignKey("MuscleGroupId")] public int MuscleGroupId { get; set; }
}