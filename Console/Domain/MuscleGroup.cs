using System.ComponentModel.DataAnnotations.Schema;

namespace Console.Domain;

public class MuscleGroup
{
    public int MuscleGroupId { get; set; }
    [Column(TypeName = "varchar(100)")] public string MuscleGroupName { get; set; } = null!;
}