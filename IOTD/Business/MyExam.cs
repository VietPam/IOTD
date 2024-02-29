using Domain.Entities;
using IOTD.Data;
using IOTD.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using static IOTD.Controllers.Exams.ExamsDTO;
using static IOTD.Controllers.Exams.ExamsModel;

namespace IOTD.Business;

public class MyExam
{
    public MyExam() { }

    public async Task<string> uploadExam(ExamUploadModel command)
    {
        string response ;
        using (DataContext context = new DataContext())
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {
                    #region check exist exam
                    var existingExam = context.exams.Where(s => s.Title == command.Title).FirstOrDefault();
                    if (existingExam is not null)
                    {
                        return response = "Exams trùng title";
                    }
                    #endregion 

                    var sqlExam = new SqlExam();
                    #region tạo exam

                    sqlExam.Title = command.Title;
                    sqlExam.TimeLimit = command.TimeLimit;
                    sqlExam.IsReadingExam = command.IsReadingExam;
                    //if (command.Sections is null)
                    //{
                    //    return response = "Exams phải có sections";
                    //}
                    #endregion 

                    #region tạo Sections

                    foreach (var section in command.Sections)
                    {
                        var sqlSection = new SqlSection();
                        sqlSection.Title = section.Title;
                        sqlSection.TextOrMediaLink = section.TextOrMediaLink;

                        foreach (var part in section.Parts)
                        {
                            var sqlPart = new SqlPart();
                            sqlPart.Text = part.Text;

                            foreach (var question in part.Questions)
                            {
                                var sqlQuestion = new SqlQuestion();
                                sqlQuestion.Text = question.Text;
                                sqlQuestion.RightAnswer = question.RightAnswer;
                                sqlQuestion.Answers = question.Answers;

                                sqlPart.Questions.Add(sqlQuestion);
                                context.questions.Add(sqlQuestion);
                            }
                            sqlSection.Parts.Add(sqlPart);
                            context.parts.Add(sqlPart);
                        }

                        sqlExam.Sections.Add(sqlSection);
                        context.sections.Add(sqlSection);
                    }
                    #endregion 
                    context.exams.Add(sqlExam);
                    await context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return response = "Thành công";
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return "Lỗi không xác định";
                }
            }
        }
    }

    public ExamGetDTO getExam(long id)
    {
        ExamGetDTO response = new ExamGetDTO();
        using (DataContext context = new DataContext())
        {
            SqlExam? sqlExam = context.exams
                .Include(e=> e.Sections).ThenInclude(s => s.Parts).ThenInclude(p => p.Questions)
                .FirstOrDefault(e => e.Id == id);
            if (sqlExam is null)
            {
                return response;
            }
            response.Title = sqlExam.Title;
            response.TimeLimit = sqlExam.TimeLimit;
            response.IsReadingExam = sqlExam.IsReadingExam;
            foreach (var section in sqlExam.Sections)
            {
                var sectionDTO = new SectionGetDTO();
                sectionDTO.Title= section.Title;
                sectionDTO.TextOrMediaLink = section.TextOrMediaLink;
                foreach (var part in section.Parts)
                {
                    var partDTO = new PartGetDTO();
                    partDTO.Text= part.Text;
                    foreach (var question in part.Questions)
                    {
                        var questionDTO = new QuestionGetDTO();
                        questionDTO.Id = question.Id;
                        questionDTO.Text = question.Text;
                        questionDTO.Answers = question.Answers;

                        partDTO.Questions.Add(questionDTO);
                    }
                    sectionDTO.Parts.Add(partDTO);
                }
                response.Sections.Add(sectionDTO);
            }
        }
        return response;
    }
    public List<ExamsGetDTO>? getExams()
    {
        List<ExamsGetDTO>? response = new List<ExamsGetDTO>();

        using (DataContext context = new DataContext())
        {
            List<SqlExam>? sqlExams = context.exams.ToList();

            foreach (var sqlExam in sqlExams)
            {
                var examDTO = new ExamsGetDTO();
                examDTO.Title = sqlExam.Title;
                examDTO.TimeLimit = sqlExam.TimeLimit;
                examDTO.IsReadingExam = sqlExam.IsReadingExam;
                
                response.Add(examDTO);
            }
        }

        return response;
    }
}