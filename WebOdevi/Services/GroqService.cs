using System.Text;
using System.Text.Json;

public class GroqService
{
    private readonly string _apiKey = ""; 
    private readonly string _apiUrl = "";
    private readonly HttpClient _httpClient;

    public GroqService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetAiResponse(string prompt)
    {
        var requestBody = new
        {
            model = "llama-3.3-70b-versatile",
            messages = new[]
            {
                new { role = "system", content = "Sen bir diyetisyensin." },
                new { role = "user", content = prompt }
            }
        };

        var request = new HttpRequestMessage(HttpMethod.Post, _apiUrl);
        request.Headers.Add("Authorization", $"Bearer {_apiKey}");
        request.Content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

        var response = await _httpClient.SendAsync(request);
        var content = await response.Content.ReadAsStringAsync();

        using var jsonDoc = JsonDocument.Parse(content);
        var root = jsonDoc.RootElement;

        // API bir hata döndürdüyse (KeyNotFound hatasını önlemek için kontrol)
        if (root.TryGetProperty("error", out var errorElement))
        {
            return "Groq API Hatası: " + errorElement.GetProperty("message").GetString();
        }

        // Başarılı yanıtı güvenli bir şekilde al
        if (root.TryGetProperty("choices", out var choices))
        {
            return choices[0].GetProperty("message").GetProperty("content").GetString();
        }

        return "Beklenmedik bir yanıt formatı alındı: " + content;
    }
}   