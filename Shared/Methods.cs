using System.Text;
using System.Text.Json;

namespace Shared;

public static class Methods
{
    public static async Task TestLogin(HttpClient httpClient)
    {
        using StringContent jsonContent = new(
            JsonSerializer.Serialize(new
            {
                email = Environment.GetEnvironmentVariable("ATMOSPHERE_EMAIL"),
                password = Environment.GetEnvironmentVariable("ATMOSPHERE_PWD")
            }),
            Encoding.UTF8,
            "application/json"
        );

        using HttpResponseMessage response = await httpClient.PostAsync("/api/account/login", jsonContent);

        response.WriteRequestToConsole();

        var jsonResponse = await response.Content.ReadAsStringAsync();

        WriteLine($"{jsonResponse}\n");
    }

    public static async Task GetAsync(HttpClient httpClient)
    {
        using HttpResponseMessage response = await httpClient.GetAsync("/posts");

        response
            .EnsureSuccessStatusCode()
            .WriteRequestToConsole();

        string jsonResponse = await response.Content.ReadAsStringAsync();
        WriteLine($"{jsonResponse}\n");
    }
}