using OpenAI;
using OpenAI.API;
using OpenAI.Chat;

namespace IntegraChatGPT3_Service
{
    public class Integra
    {
        public bool Conectado { get; private set; }
        public string ApiKEY { get; private set; } = "";
        public string ApiORG { get; private set; } = "";

        public Integra() => Autentica();

        public void Autentica()
        {
            try
            {
                string pathAuth = $"{System.IO.Directory.GetCurrentDirectory()}{(System.IO.Directory.GetCurrentDirectory().EndsWith("\\") == true ? "" : "\\")}.openai";
                OpenAIClient openAIClient = new OpenAIClient(OpenAIAuthentication.LoadFromDirectory(pathAuth));
                ApiKEY = openAIClient.OpenAIAuthentication.ApiKey;
                ApiORG = openAIClient.OpenAIAuthentication.OrganizationId;

                this.Conectado = true;
            }
            catch (Exception)
            {
                this.Conectado = false;
            }
        }

        public async Task<OpenAI.Models.Model?> GetModel(string modelType)
        {
            try
            {
                if (!this.Conectado)
                    return null;

                var api = new OpenAIClient();
                return await api.ModelsEndpoint.GetModelDetailsAsync(modelType);
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<ChatResponse?> GetConclusion()
        {
            if (!this.Conectado)
                return null;

            var api = new OpenAIClient();
            var chatPrompts = new List<ChatPrompt>
            {
                new ChatPrompt("system", "You are a helpful assistant."),
                new ChatPrompt("user", "Who won the world series in 2020?"),
                new ChatPrompt("assistant", "The Los Angeles Dodgers won the World Series in 2020."),
                new ChatPrompt("user", "Where was it played?"),
            };
            var chatRequest = new ChatRequest(chatPrompts);
            var result = await api.ChatEndpoint.GetCompletionAsync(chatRequest);
            //Console.WriteLine(result.FirstChoice);
            return result;
        }

        public async Task<ChatResponse?> GetConclusion(string question)
        {
            if (!this.Conectado)
                return null;

            var api = new OpenAIClient();
            var chatPrompts = new List<ChatPrompt>
            {
                new ChatPrompt("system", "You are a helpful assistant."),
                new ChatPrompt("user", question),
            };
            var chatRequest = new ChatRequest(chatPrompts);
            var result = await api.ChatEndpoint.GetCompletionAsync(chatRequest);
            return result;
        }

        
    }

}