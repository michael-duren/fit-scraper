using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using Console.Context;
using Console.Domain;
using Shared;

#region init

// setup dotenv
DotEnv.Load();
string domain = Environment.GetEnvironmentVariable("DOMAIN") ?? "www.example.com";

using (new ChangeConsoleColor(ConsoleColor.Red))
{
    WriteLine("Starting Program.");
    WriteLine($"DOMAIN: {domain}");
    WriteLine(new string('.', 50));
}

// make requests?
// await MakeRequests(domain);

// parse using angle sharp

string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
string htmlPath = Path.Combine(docPath, "log.html");

string htmlContent = await File.ReadAllTextAsync(htmlPath);

// CODE to parse individual workout
IConfiguration config = Configuration.Default.WithDefaultLoader();
IBrowsingContext context = BrowsingContext.New(config);
IDocument document = await context.OpenAsync(req => req.Content(htmlContent));
// serialize the original doc
IHtmlCollection<IElement> exorciseContainerList = document.QuerySelectorAll(".et_pb_blurb_container");
List<Exercise> exercises = [];

// await using StreamWriter outputFile = new(Path.Combine(docPath, $"titles-{DateTime.Now.ToString("s")}.txt"));
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



foreach (var exercise in exercises)
{
    WriteLine("EXERCISE:");
    WriteLine($"NAME: {exercise.Name}, VIDEO: {exercise.VideoLink}");
    WriteLine($"DESCRIPTION: {exercise.Description}");
}

#endregion

using AppDbContext appDbContext = new();

