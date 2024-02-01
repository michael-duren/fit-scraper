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
    public DbSet<WorkoutType> WorkoutTypes { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<WorkoutWorkoutType> WorkoutWorkoutTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Fitness;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WorkoutType>().HasData(
            new WorkoutType { WorkoutTypeId = 1, WorkoutTypeName = "Back" },
            new WorkoutType { WorkoutTypeId = 2, WorkoutTypeName = "Biceps" },
            new WorkoutType { WorkoutTypeId = 3, WorkoutTypeName = "Chest" },
            new WorkoutType { WorkoutTypeId = 4, WorkoutTypeName = "Shoulders" },
            new WorkoutType { WorkoutTypeId = 5, WorkoutTypeName = "Triceps" },
            new WorkoutType { WorkoutTypeId = 6, WorkoutTypeName = "Legs" },
            new WorkoutType { WorkoutTypeId = 7, WorkoutTypeName = "Calves" },
            new WorkoutType { WorkoutTypeId = 8, WorkoutTypeName = "Push" },
            new WorkoutType { WorkoutTypeId = 9, WorkoutTypeName = "Pull" },
            new WorkoutType { WorkoutTypeId = 10, WorkoutTypeName = "Push/Pull" }
        );
    }
}