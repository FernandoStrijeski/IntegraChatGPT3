using IntegraChatGPT3_Service;
using OpenAI.Chat;
using OpenAI.Models;

namespace IntegraChatGPT_3_VS22.Classes
{
    public class ConsomeServico
    {     
        public async Task<Model?> GetModel() => await IntegraServico.integra.GetModel("text-davinci-003");
        
        public async Task<ChatResponse?> GetConclusion() => await IntegraServico.integra.GetConclusion();

        public async Task<ChatResponse?> GetConclusion(string question) => await IntegraServico.integra.GetConclusion(question);

    }
}
