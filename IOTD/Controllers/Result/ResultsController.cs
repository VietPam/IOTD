using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static IOTD.Controllers.Exams.ExamsModel;
using static IOTD.Controllers.Result.ResultsModel;

namespace IOTD.Controllers.Result;

[Route("api/[controller]")]
[ApiController]
public class ResultsController : ControllerBase
{
    [HttpPost]
    [Route("{IdExam}")]
    public async Task<IActionResult> SubmitExamAsync([FromRoute] long IdExam, [FromBody] ResultSubmitModel command)
    {
        return Ok(await Program.api_result.SubmitExamAsync(IdExam, command));
    }
    //       {
    //  "timeBegin": "2024-02-29 08:30:00",
    //  "timeEnd": "2024-02-29 08:30:00",
    //  "logs": [
    //    {
    //      "idQuestion": 6384481370657909,
    //      "answer": "Đây là"
    //    }
    //  ]
    //}

    [HttpGet]
    [Route("")]
    public IActionResult GetResults()
    {
        return Ok(Program.api_result.GetResults());
    }
}
