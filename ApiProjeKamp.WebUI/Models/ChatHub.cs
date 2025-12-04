using Microsoft.AspNetCore.SignalR;
using NuGet.Versioning;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiProjeKamp.WebUI.Models
{
    public class ChatHub : Hub
    {
        private const string apiKey = ""; 
        private const string modelgpt = "gpt-4o-mini";
        private readonly IHttpClientFactory _httpClientFactory;

        public ChatHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private static readonly Dictionary<string, List<Dictionary<string, string>>> _history = new();

        public override Task OnConnectedAsync()
        {
            _history[Context.ConnectionId] = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string>
                {
                    ["role"] = "system",
                    ["content"] = "You are a helpful assistant. Keep answers concise."
                }
            };
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            _history.Remove(Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
        public async Task SendMessage(string userMessage)
        {
            await Clients.Caller.SendAsync("ReceiveUserEcho", userMessage);
            var history = _history[Context.ConnectionId];
            history.Add(new Dictionary<string, string>
            {
                ["role"] = "user",
                ["content"] = userMessage
            });
            await StreamOpenAI(history, Context.ConnectionAborted);
        }

        public async Task StreamOpenAI(List<Dictionary<string, string>> history, CancellationToken cancellationToken)
        {
            var client = _httpClientFactory.CreateClient("openai");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
            var payload = new
            {
                model = modelgpt,
                messages = history,
                stream = true,
                temperature = 0.2
            };

            using var request = new HttpRequestMessage(HttpMethod.Post, "v1/chat/completions");
            request.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            using var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync(cancellationToken);
            using var reader = new StreamReader(responseStream);

            var sb = new StringBuilder();
            while (!reader.EndOfStream && !cancellationToken.IsCancellationRequested)
            {
                var line = await reader.ReadLineAsync();
                if (string.IsNullOrWhiteSpace(line) || !line.StartsWith("data: ")) continue;
                var jsonData = line.Substring("data: ".Length).Trim();
                if (jsonData == "[DONE]") break;
                try
                {
                    var chunk = JsonSerializer.Deserialize<ChatStreamChunk>(jsonData);
                    var delta = chunk?.Choices?.FirstOrDefault()?.Delta?.Content;
                    if (!string.IsNullOrEmpty(delta))
                    {
                        sb.Append(delta);
                        await Clients.Caller.SendAsync("ReceiveToken", delta, cancellationToken);
                    }
                }
                catch
                {
                    // Handle JSON parsing errors if necessary
                }
            }

            var full = sb.ToString();
            history.Add(new Dictionary<string, string>
            {
                ["role"] = "assistant",
                ["content"] = full
            });
            await Clients.Caller.SendAsync("CompleteMessage", full, cancellationToken);
        }
        //Stream parse modelleri

        //sealed = override edilemez, başka sınıflar tarafından miras alınamaz, türetilemez
        private sealed class ChatStreamChunk
        {
            [JsonPropertyName("choices")] public List<Choice>? Choices { get; set; }

        }
        private sealed class Choice
        {
            [JsonPropertyName("delta")] public Delta? Delta { get; set; }
            [JsonPropertyName("finish_reason")] public string? FinishReason { get; set; }

        }
        private sealed class Delta
        {
            [JsonPropertyName("content")] public string? Content { get; set; }
            [JsonPropertyName("role")] public string? Role { get; set; }

        }
    }
}
