﻿// <auto-generated />
using Console.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Console.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Console.Domain.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ExerciseId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("VideoLink")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("integer");

                    b.HasKey("ExerciseId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("Console.Domain.Workout", b =>
                {
                    b.Property<int>("WorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("WorkoutId"));

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.HasKey("WorkoutId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("Console.Domain.WorkoutType", b =>
                {
                    b.Property<int>("WorkoutTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("WorkoutTypeId"));

                    b.Property<string>("WorkoutTypeName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("WorkoutTypeId");

                    b.ToTable("WorkoutTypes");

                    b.HasData(
                        new
                        {
                            WorkoutTypeId = 1,
                            WorkoutTypeName = "Back"
                        },
                        new
                        {
                            WorkoutTypeId = 2,
                            WorkoutTypeName = "Biceps"
                        },
                        new
                        {
                            WorkoutTypeId = 3,
                            WorkoutTypeName = "Chest"
                        },
                        new
                        {
                            WorkoutTypeId = 4,
                            WorkoutTypeName = "Shoulders"
                        },
                        new
                        {
                            WorkoutTypeId = 5,
                            WorkoutTypeName = "Triceps"
                        },
                        new
                        {
                            WorkoutTypeId = 6,
                            WorkoutTypeName = "Legs"
                        },
                        new
                        {
                            WorkoutTypeId = 7,
                            WorkoutTypeName = "Calves"
                        },
                        new
                        {
                            WorkoutTypeId = 8,
                            WorkoutTypeName = "Push"
                        },
                        new
                        {
                            WorkoutTypeId = 9,
                            WorkoutTypeName = "Pull"
                        },
                        new
                        {
                            WorkoutTypeId = 10,
                            WorkoutTypeName = "Push/Pull"
                        });
                });

            modelBuilder.Entity("Console.Domain.WorkoutWorkoutType", b =>
                {
                    b.Property<int>("WorkoutWorkoutTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("WorkoutWorkoutTypeId"));

                    b.Property<int>("WorkoutId")
                        .HasColumnType("integer");

                    b.Property<int>("WorkoutTypeId")
                        .HasColumnType("integer");

                    b.HasKey("WorkoutWorkoutTypeId");

                    b.ToTable("WorkoutWorkoutTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
