using System.Net;
using AngleSharp;
using AngleSharp.Dom;
using Shared;

public partial class Program
{
    static async Task<List<IDocument>> MakeRequests(string domain, HttpClient client)
    {
        #region request

        List<string> allLinks = [];

        // get links
        for (int i = 0; i < 25; i++)
        {
            // get url
            string url = i == 0 ? $"https://{domain}/itt-workouts/" : $"https://{domain}/itt-workouts/page/{i + 1}/";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                IConfiguration config = Configuration.Default.WithDefaultLoader();
                IBrowsingContext context = BrowsingContext.New(config);
                string content = await response.Content.ReadAsStringAsync();
                IDocument document = await context.OpenAsync(req => req.Content(content));
                List<string> parsedLinks = ParseWorkoutLinks(document: document);
                allLinks.AddRange(parsedLinks);
            }
            else
            {
                using (new ChangeConsoleColor(ConsoleColor.Red))
                {
                    WriteLine($"ERROR WITH REQUEST: {url}");
                }
            }
        }

        #endregion

        List<IDocument> workoutDetailPages = [];
        foreach (var allLink in allLinks)
        {
            var workoutDetails = await client.GetAsync(allLink);

            if (workoutDetails.IsSuccessStatusCode)
            {
                IConfiguration config = Configuration.Default.WithDefaultLoader();
                IBrowsingContext context = BrowsingContext.New(config);
                string content = await workoutDetails.Content.ReadAsStringAsync();
                IDocument document = await context.OpenAsync(req => req.Content(content));

                workoutDetailPages.Add(document);
            }
            else
            {
                using (new ChangeConsoleColor(ConsoleColor.Red))
                {
                    WriteLine($"ERROR WITH REQUEST: {allLink}");
                }
            }
        }

        return workoutDetailPages;
    }
}