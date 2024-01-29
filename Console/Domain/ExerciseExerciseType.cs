using System.ComponentModel.DataAnnotations.Schema;

namespace Console.Domain;

public class ExerciseExerciseType
{
    public int ExerciseExerciseTypeId { get; set; }
    [ForeignKey("ExerciseId")] public int ExerciseId { get; set; }
    [ForeignKey("ExerciseTypeId")] public int ExerciseTypeId { get; set; }
}