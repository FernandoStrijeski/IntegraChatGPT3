using Microsoft.AspNetCore.Mvc;
using IntegraChatGPT_3_VS22.Classes;
using NPOI.SS.Formula.Functions;
using Newtonsoft.Json;

[ApiController]
public class IntegraController : ControllerBase
{
    [HttpGet]
    [Route("api/getconclusion")]
    public ActionResult<string> GetConclusion(string question)
    {
        ConsomeServico consomeServico = new();
        var result = consomeServico.GetConclusion(question).Result?.FirstChoice;
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet]
    [Route("api/addFineTune")]
    public ActionResult<string> AddFineTune(string prompt, string listaJson)
    {
        List<string>? examples = new();
        examples = JsonConvert.DeserializeObject<List<string>>(listaJson);

        if (examples == null || examples.Count == 0)
            return NotFound();

        FineTune fineTune = new(IntegraServico.ApiKEY, IntegraServico.FineTuneModelHumanus);
        var result = fineTune.FineTuneChatGpt(prompt, examples);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpGet]
    [Route("api/importFineTune")]
    public ActionResult<string> ImportFineTune(string prompts)
    {
        List<PromptLine>? listPrompts = JsonConvert.DeserializeObject<List<PromptLine>>(prompts);
        if (listPrompts != null)
        {
            foreach (PromptLine promptItem in listPrompts)
            {
                string? prompt = promptItem.prompt;
                string? completion = promptItem.completion;

                if (!string.IsNullOrEmpty(prompt) && !string.IsNullOrEmpty(completion))
                {
                    List<string>? examples = new() { completion };

                    FineTune fineTune = new(IntegraServico.ApiKEY, IntegraServico.FineTuneModelHumanus);
                    var result = fineTune.FineTuneChatGpt(prompt, examples);
                    if (result == null)
                    {
                        return NotFound();
                    }
                    return Ok(result);
                }

            }
        }

        return null;
    }
}