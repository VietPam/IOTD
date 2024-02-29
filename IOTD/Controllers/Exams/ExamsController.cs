using Microsoft.AspNetCore.Mvc;
using static IOTD.Controllers.Exams.ExamsModel;

namespace IOTD.Controllers.Exams;

public class ExamsController : ControllerBase
{
    [HttpPost]
    [Route("")]
    public async Task<IActionResult> CreateNewExamAsync([FromBody]ExamUploadModel command)
    {
        return Ok(await Program.api_exam.uploadExam(command));
    }
}
