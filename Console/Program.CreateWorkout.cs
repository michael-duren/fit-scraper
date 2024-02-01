using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Console.Context;
using Console.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Shared;

public partial class Program
{
    private static async Task CreateWorkout(IDocument document, AppDbContext context)
    {
        #region setup

        IElement? workoutInformation = document.QuerySelector(".entry-title");
        IHtmlCollection<IElement> exorciseContainerList = document.QuerySelectorAll(".et_pb_blurb_container");
        List<Exercise> exercises = [];

        string workoutName = workoutInformation?.TextContent ?? Guid.NewGuid().ToString();

        #endregion

        // mark the start of transaction
        await using (IDbContextTransaction transaction = await context.Database.BeginTransactionAsync())
        {
            try
            {
                #region create initial workout

                Workout workout = new()
                {
                    Name = workoutName
                };
                context.Workouts.Add(workout);
                await context.SaveChangesAsync();

                #endregion

                List<WorkoutType> workoutTypes = await
                    context
                        .WorkoutTypes
                        .Where(et => workout.Name.ToLower().Contains(et.WorkoutTypeName.ToLower()))
                        .ToListAsync();

                foreach (WorkoutType workoutType in workoutTypes)
                {
                    context.Add(new WorkoutWorkoutType
                    {
                        WorkoutId = workout.WorkoutId,
                        WorkoutTypeId = workoutType.WorkoutTypeId
                    });
                }

                foreach (var container in exorciseContainerList)
                {
                    IElement? h1 = container.QuerySelector(".et_pb_module_header");
                    IHtmlAnchorElement? anchor = (IHtmlAnchorElement?)h1?.FirstChild;

                    if (anchor is null) continue;

                    IElement? desc = container.QuerySelector(".et_pb_blurb_description");

                    Exercise exercise = new()
                    {
                        Name = anchor.TextContent.Trim(),
                        Description = desc?.TextContent.Trim() ?? "",
                        VideoLink = anchor.Href.Trim(),
                        WorkoutId = workout.WorkoutId
                    };

                    exercises.Add(exercise);
                }

                await context.Exercises.AddRangeAsync(exercises);

                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync(); // stop here if not correct
                using (new ChangeConsoleColor(ConsoleColor.Red))
                {
                    WriteLine(e);
                }

                throw;
            }

            // if we make it here it went alright
            await transaction.CommitAsync();

            // write result to console
            using (new ChangeConsoleColor(ConsoleColor.Green))
            {
                WriteLine($"WORKOUT: {workoutName}");
                WriteLine("WRITTEN TO DB");
            }
        }
    }
}