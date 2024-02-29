using Domain.Entities;
using Ielts_online_test_dotnet.Model;
using IOTD.Data;
using Microsoft.EntityFrameworkCore;
using static IOTD.Controllers.Result.ResultsDTO;
using static IOTD.Controllers.Result.ResultsModel;

namespace IOTD.Business;

public class MyResult
{
    public MyResult() { }
    public List<SqlQuestion> getQuestionsFromExamId(long examId)
    {
        using (DataContext context = new DataContext())
        {
            var questions = context.questions
            .Where(q => q.Part.Section.Exam.Id == examId)
            .ToList();

            return questions;
        }
    }
    public async Task<string> SubmitExamAsync(long examId, ResultSubmitModel command)
    {
        using (DataContext context = new DataContext())
        {
            var sqlExam = context.exams.FirstOrDefault();
            if (sqlExam is null)
            {
                return "Sai ExamID";
            }

            var sqlResult = new SqlResult();
            sqlResult.TimeBegin = DateTime.Parse(command.TimeBegin).ToUniversalTime();
            sqlResult.TimeEnd = DateTime.Parse(command.TimeEnd).ToUniversalTime();
            sqlResult.Exam = sqlExam;
            sqlResult.RightCount = 0;

            if (command.Logs is null || !command.Logs.Any())
            {
                return "Bài làm phải trả lời ít nhất một câu hỏi. Vui lòng thử lại!";
            }

            foreach (var log in command.Logs)
            {
                var question = context.questions.FirstOrDefault(q=> q.Id == log.IdQuestion) ;
                if (question is not null)
                {
                    var sqlLog = new SqlLog();
                    sqlLog.Result = sqlResult;
                    sqlLog.Answer = log.Answer;
                    sqlLog.Question = question;
                    sqlLog.IsCorrect = false;

                    if (question.RightAnswer.CompareTo(log.Answer) == 0)
                    {
                        sqlLog.IsCorrect = true;
                        sqlResult.RightCount++;
                    }

                    sqlResult.AnswerLogs.Add(sqlLog);
                    context.logs.Add(sqlLog);
                }
                else if (question is null)
                {
                    return $"Không tìm thấy câu hỏi với id = {log.IdQuestion}, bài làm không được lưu!";
                }
            }

            context.results.Add(sqlResult);
            await context.SaveChangesAsync();

            return "Nộp bài thành công";
        }
    }
    public List<ResultsGetDTO>? GetResults()
    {
        List<ResultsGetDTO>? response = new List<ResultsGetDTO>();

        using (DataContext context = new DataContext())
        {
            var sqlResults = context.results.ToList();
            foreach (var sqlResult in sqlResults)
            {
                var resultDTO = new ResultsGetDTO();
                resultDTO.IdResult = sqlResult.Id;
                resultDTO.RightCount = sqlResult.RightCount;

                response.Add(resultDTO);
            }
            context.SaveChanges();
        }

        return response;
    }
}
