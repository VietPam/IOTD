using Domain.Entities;
using IOTD.Data;
using IOTD.Entities;
using System.Security.Cryptography.X509Certificates;
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

}
