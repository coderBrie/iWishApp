using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OpenAI_API;




namespace iWishApp.Models
{



    public class ChatbotService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private const string OpenAIEndpoint = "https://api.openai.com/v1/engines/davinci-codex/completions";

        public ChatbotService(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
        }

        public async Task<string> GetChatbotResponse(string message)
        {
            var prompt = "User: " + message + "\nChatGPT: ";

            var requestContent = new
            {
                prompt = prompt,
                max_tokens = 50, // Set the desired number of tokens for the response
                temperature = 0.6, // Adjust the temperature to control the randomness of the response
            };

            var jsonRequest = JsonSerializer.Serialize(requestContent);
            var httpContent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

            var response = await _httpClient.PostAsync(OpenAIEndpoint, httpContent);

            if (!response.IsSuccessStatusCode)
            {
                // Handle the API error response
                throw new Exception($"OpenAI API request failed with status code {response.StatusCode}: {response.ReasonPhrase}");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<ChatbotResponse>(jsonResponse);

            return responseObject?.choices?.Length > 0 ? responseObject.choices[0].message.Trim() : string.Empty;
        }
    }


    public class ChatbotResponse
    {
        public string id { get; set; }
        public string ObjectType { get; set; } // Renamed the property from "object" to "ObjectType"
        public double created { get; set; }
        public string model { get; set; }
        public double usage { get; set; }
        public ChatbotChoice[] choices { get; set; }
    }

    public class ChatbotChoice
    {
        public string message { get; set; }
        public double index { get; set; }
        public double[] logprobs { get; set; }
        public string finish_reason { get; set; }
    }

}