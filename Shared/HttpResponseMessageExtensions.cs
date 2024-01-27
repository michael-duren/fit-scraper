namespace Shared;

public static class HttpResponseMessageExtensions
{
    public static async void WriteRequestToConsole(this HttpResponseMessage? response)
    {
        if (response is null)
        {
            return;
        }

        // REQUEST INFORMATION
        HttpRequestMessage? request = response.RequestMessage;
        using (new ChangeConsoleColor(ConsoleColor.Blue))
        {
            if (request is not null)
            {
                Banner.WriteBanner("REQUEST INFORMATION", '*', 100);
                Write($"{request.Method} ");
                Write($"{request.RequestUri} ");
                WriteLine($"HTTP/{request.Version}");
                if (request.Content is not null)
                {
                    string content = await request.Content.ReadAsStringAsync();
                    WriteLine($"REQUEST PAYLOAD: {content}");
                }

                Banner.WriteBanner("END REQUEST INFORMATION", '-', 100);
            }
        }


        using (new ChangeConsoleColor(ConsoleColor.DarkMagenta))
        {
            Banner.WriteBanner("RESPONSE INFORMATION", '*', 100);
            WriteLine($"Response Status: {response.StatusCode}");
            WriteLine($"Response Content: {response.Content}");
            WriteLine($"Response Status: {response.Content}");
            Banner.WriteBanner("END RESPONSE INFORMATION", '*', 100);
        }

        using (new ChangeConsoleColor(ConsoleColor.Red))
        {
            Banner.WriteBanner("RESPONSE HEADERS", '*', 100);
            Write(response.Headers);
            Banner.WriteBanner("END RESPONSE HEADERS", '-', 100);
        }
    }
}