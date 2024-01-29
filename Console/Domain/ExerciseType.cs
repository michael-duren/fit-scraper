using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.Domain;

public class ExerciseType
{
    [Key] public int ExerciseTypeId { get; set; }
    [Column(TypeName = "varchar(100)")] public string ExerciseTypeName { get; set; } = null!;
}