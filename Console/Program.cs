using System.Net;
using Shared;

// setup dotenv
DotEnv.Load();
string domain = Environment.GetEnvironmentVariable("DOMAIN") ?? "www.example.com";

using (new ChangeConsoleColor(ConsoleColor.Red))
{
    WriteLine("Starting Program.");
    WriteLine($"DOMAIN: {domain}");
    WriteLine(new string('.', 50));
}


HttpClientHandler handler = new();
CookieContainer cookieContainer = new();
handler.CookieContainer = cookieContainer;

WriteLine("Send request? (Y/n)");

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

string? key = ReadLine();
if (key?.ToLower() != "y")
{
    Environment.Exit(0);
}

HttpResponseMessage response = await client.GetAsync($"https://{domain}/2023/10/26/239-back-2023/");
response.WriteRequestToConsole();

string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

await using StreamWriter outputFile = new(Path.Combine(docPath, $"log-{DateTime.Now.ToString("s")}.txt"));
string content = await response.Content.ReadAsStringAsync();
outputFile.Write(content);

// get links for each page/exercise
for (int i = 0; i < 25; i++)
{
    HttpResponseMessage responseMessage =
        await client.GetAsync($"https://{domain}/itt-workouts/page/{i}/?el_dbe_page");
}