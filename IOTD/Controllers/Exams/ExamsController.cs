using Microsoft.AspNetCore.Mvc;
using static IOTD.Controllers.Exams.ExamsModel;

namespace IOTD.Controllers.Exams;

public class ExamsController : ControllerBase
{
    [HttpPost]
    [Route("")]
    public IActionResult CreateNewExam([FromBody]ExamUploadModel command)
    {
        return Ok(Program.api_exam.uploadExam(command));
    }
}
