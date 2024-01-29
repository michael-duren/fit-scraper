using System.Data.SqlClient;
using Console.Domain;
using Microsoft.EntityFrameworkCore;

namespace Console.Context;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseType> ExerciseTypes { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<ExerciseExerciseType> ExerciseExerciseTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Fitness;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExerciseType>().HasData(
            new ExerciseType { ExerciseTypeId = 1, ExerciseTypeName = "Back" },
            new ExerciseType { ExerciseTypeId = 2, ExerciseTypeName = "Biceps" },
            new ExerciseType { ExerciseTypeId = 3, ExerciseTypeName = "Chest" },
            new ExerciseType { ExerciseTypeId = 4, ExerciseTypeName = "Shoulders" },
            new ExerciseType { ExerciseTypeId = 5, ExerciseTypeName = "Triceps" },
            new ExerciseType { ExerciseTypeId = 6, ExerciseTypeName = "Legs" },
            new ExerciseType { ExerciseTypeId = 7, ExerciseTypeName = "Calves" },
            new ExerciseType { ExerciseTypeId = 8, ExerciseTypeName = "Push" },
            new ExerciseType { ExerciseTypeId = 9, ExerciseTypeName = "Pull" },
            new ExerciseType { ExerciseTypeId = 10, ExerciseTypeName = "Push/Pull" }
        );
    }
}