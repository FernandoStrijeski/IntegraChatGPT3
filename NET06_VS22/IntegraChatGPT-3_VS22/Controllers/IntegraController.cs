using Microsoft.AspNetCore.Mvc;
using IntegraChatGPT_3_VS22.Classes;
using NPOI.SS.Formula.Functions;

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
}