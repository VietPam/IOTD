using Microsoft.AspNetCore.Mvc;
using static IOTD.Controllers.Exams.ExamsModel;

namespace IOTD.Controllers.Exams;
[Route("api/[controller]")]
[ApiController]
public class ExamsController : ControllerBase
{
    [HttpPost]
    [Route("")]
    public async Task<IActionResult> CreateNewExamAsync([FromBody]ExamUploadModel command)
    {
        return Ok(await Program.api_exam.uploadExam(command));
    }

    [HttpGet]
    [Route("{Id}")]
    public IActionResult GetExam(long Id)
    {
        return Ok(Program.api_exam.getExam(Id));
    }

    [HttpGet]
    [Route("")]
    public IActionResult GetExams()
    {
        return Ok(Program.api_exam.getExams());
    }


}
