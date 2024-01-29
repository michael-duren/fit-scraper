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
            #region create initial workout

            Workout workout = new()
            {
                Name = workoutName
            };
            context.Workouts.Add(workout);
            await context.SaveChangesAsync();

            #endregion

            List<ExerciseType> exerciseTypes = await
                context
                    .ExerciseTypes
                    .Where(et => workout.Name.ToLower().Contains(et.ExerciseTypeName.ToLower()))
                    .ToListAsync();


            foreach (var container in exorciseContainerList)
            {
                IElement? h1 = container.QuerySelector(".et_pb_module_header");
                IHtmlAnchorElement? anchor = (IHtmlAnchorElement?)h1?.FirstChild;

                if (anchor is null) continue;

                IElement? desc = container.QuerySelector(".et_pb_blurb_description");

                Exercise exercise = new()
                {
                    Name = anchor.TextContent,
                    Description = desc?.TextContent ?? "",
                    VideoLink = anchor.Href
                };

                exercises.Add(exercise);
            }


            using (new ChangeConsoleColor(ConsoleColor.Blue))
            {
                WriteLine($"WORKOUT: {workout.Name}");
                WriteLine();

                foreach (ExerciseType exerciseType in exerciseTypes)
                {
                    WriteLine($"WORKOUT TYPE: {exerciseType.ExerciseTypeName}");
                }

                WriteLine($"EXERCISES: ");
                foreach (Exercise exercise in exercises)
                {
                    WriteLine("EXERCISE:");
                    WriteLine($"NAME: {exercise.Name.Trim()}, VIDEO: {exercise.VideoLink.Trim()}");
                    WriteLine($"DESCRIPTION: {exercise.Description.Trim()}");
                }
            }
        }
    }
}