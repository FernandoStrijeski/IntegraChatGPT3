namespace IntegraChatGPT_3_VS22.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using Newtonsoft.Json;
    public class FineTune
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _chatGptModelId;

        public FineTune(string apiKey, string chatGptModelId)
        {
            _apiKey = apiKey;
            _chatGptModelId = chatGptModelId; _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");
            _httpClient.BaseAddress = new Uri("https://api.openai.com/v1/");
        }
        public string FineTuneChatGpt(string prompt, List<string> examples)
        {
            var fineTuneRequest = new
            {
                model = _chatGptModelId,
                examples = examples,
                prompt = prompt,
                temperature = 0.7,
                max_tokens = 50,
                n = 1,
                stop = "\n"
            };

            var jsonRequest = JsonConvert.SerializeObject(fineTuneRequest);
            var content = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
            var response = _httpClient.PostAsync("engines/fine-tunes", content).Result;
            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to fine tune ChatGPT model");

            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var fineTuneResponse = JsonConvert.DeserializeObject<dynamic>(jsonResult);

            return fineTuneResponse["choices"][0]["text"];
        }
    }
}