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
    public DbSet<MuscleGroup> MuscleGroups { get; set; }
    public DbSet<Workout> Workouts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database={Fitness};");
    }
}