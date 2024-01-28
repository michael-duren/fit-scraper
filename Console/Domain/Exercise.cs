using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.Domain;

public class Exercise
{
    [Key] public int ExerciseId { get; set; }
    [Column(TypeName = "varchar(100)")] public string Name { get; set; } = null!;
    [Column(TypeName = "varchar(100)")] public string VideoLink { get; set; } = null!;
    [Column(TypeName = "varchar(100)")] public string Description { get; set; } = null!;
}