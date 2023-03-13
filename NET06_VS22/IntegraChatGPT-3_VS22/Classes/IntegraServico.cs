using IntegraChatGPT3_Service;
using OpenAI.Chat;
using OpenAI.Models;
using System.Runtime.CompilerServices;

namespace IntegraChatGPT_3_VS22.Classes
{
    public static class IntegraServico
    {
        public static Integra integra = new();
        public static string FineTuneModelHumanus { get; private set; } = "davinci-humanus-rh"; // "text-davinci-003";
        public static string ApiKEY { get; private set; } = "";
        public static string ApiORG { get; private set; } = "";

        public static void IniciaServico()
        {
            ApiKEY = integra.ApiKEY;
            ApiORG = integra.ApiORG;
        }

    }
}
