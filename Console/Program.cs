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

await using AppDbContext appDbContext = new();

await CreateWorkout(document, appDbContext);

#endregion