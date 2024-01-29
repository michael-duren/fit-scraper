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

            modelBuilder.Entity("Console.Domain.ExerciseExerciseType", b =>
                {
                    b.Property<int>("ExerciseExerciseTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ExerciseExerciseTypeId"));

                    b.Property<int>("ExerciseId")
                        .HasColumnType("integer");

                    b.Property<int>("ExerciseTypeId")
                        .HasColumnType("integer");

                    b.HasKey("ExerciseExerciseTypeId");

                    b.ToTable("ExerciseExerciseTypes");
                });

            modelBuilder.Entity("Console.Domain.ExerciseType", b =>
                {
                    b.Property<int>("ExerciseTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ExerciseTypeId"));

                    b.Property<string>("ExerciseTypeName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("ExerciseTypeId");

                    b.ToTable("ExerciseTypes");

                    b.HasData(
                        new
                        {
                            ExerciseTypeId = 1,
                            ExerciseTypeName = "Back"
                        },
                        new
                        {
                            ExerciseTypeId = 2,
                            ExerciseTypeName = "Biceps"
                        },
                        new
                        {
                            ExerciseTypeId = 3,
                            ExerciseTypeName = "Chest"
                        },
                        new
                        {
                            ExerciseTypeId = 4,
                            ExerciseTypeName = "Shoulders"
                        },
                        new
                        {
                            ExerciseTypeId = 5,
                            ExerciseTypeName = "Triceps"
                        },
                        new
                        {
                            ExerciseTypeId = 6,
                            ExerciseTypeName = "Legs"
                        },
                        new
                        {
                            ExerciseTypeId = 7,
                            ExerciseTypeName = "Calves"
                        },
                        new
                        {
                            ExerciseTypeId = 8,
                            ExerciseTypeName = "Push"
                        },
                        new
                        {
                            ExerciseTypeId = 9,
                            ExerciseTypeName = "Pull"
                        },
                        new
                        {
                            ExerciseTypeId = 10,
                            ExerciseTypeName = "Push/Pull"
                        });
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
#pragma warning restore 612, 618
        }
    }
}
