using Microsoft.AspNetCore.Mvc;
using IntegraChatGPT_3_VS22.Classes;

[ApiController]
public class IntegraController : ControllerBase
{
    [HttpGet]
    [Route("api/getconclusion")]
    public ActionResult<T> GetConclusion(string question)
    {
        ConsomeServico consomeServico = new();
        var result = consomeServico.GetConclusion(question).Result?.FirstChoice;
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}