using Microsoft.AspNetCore.Mvc;

namespace IOTD.Controllers.Exams;

public class ExamsController : ControllerBase
{
    [HttpPost]
    [Route("")]
    public IActionResult CreateNewExam()
    {
        return Ok();
    }
}
