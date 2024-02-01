using System.Net;
using AngleSharp.Dom;
using Console.Context;
using Npgsql;
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

string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

#endregion

await using AppDbContext appDbContext = new();

if (!(await appDbContext.Database.CanConnectAsync()))
{
    throw new NpgsqlException($"ERROR CONNECTING");
}

using (new ChangeConsoleColor(ConsoleColor.Green))
{
    WriteLine("CONNECTED TO DB");
}

#region setup httpclient

HttpClientHandler handler = new();
CookieContainer cookieContainer = new();
handler.CookieContainer = cookieContainer;

using HttpClient client = new(handler);
Cookie wpLoggedIn = new(name: Environment.GetEnvironmentVariable("WORDPRESS_LOGGED_IN_NAME") ?? "wp_login",
    value:
    Environment.GetEnvironmentVariable("WORDPRESS_LOGGED_IN_VALUE")
)
{
    Domain = domain
};
cookieContainer.Add(wpLoggedIn);
Cookie wpSec = new(Environment.GetEnvironmentVariable("WORDPRESS_SEC_NAME") ?? "wp_sec",
    Environment.GetEnvironmentVariable("WORDPRESS_SEC_VALUE"))
{
    Domain = domain
};
cookieContainer.Add(wpSec);

#endregion

#region prompt user

WriteLine("Send request? (Y/n)");

string? key = ReadLine();
if (key?.ToLower() != "y")
{
    Environment.Exit(0);
}

#endregion

List<IDocument> documents = await MakeRequests(domain, client);

foreach (IDocument document in documents)
{
    await CreateWorkout(document, appDbContext);
}

WriteLine("IF WE GOT THIS FAR WE PROBS DID IT");