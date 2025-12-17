using System.Net.Http.Headers;
using System.Text.Json;

namespace WebOdevi.Services
{
    public class OpenAiService
    {
        private readonly HttpClient _httpClient;

        public OpenAiService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", config["OpenAI:ApiKey"]);
        }

        public async Task<string> GetDietPlan(string prompt)
        {
            var requestBody = new
            {
                model = "gpt-4.1-mini",
                input = $"Boy, kilo ve hedefe göre diyet öner:\n{prompt}"
            };

            var response = await _httpClient.PostAsJsonAsync(
                "https://api.openai.com/v1/responses",
                requestBody
            );

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);

            return doc
                .RootElement
                .GetProperty("output")[0]
                .GetProperty("content")[0]
                .GetProperty("text")
                .GetString();
        }
    }
}
