using IOTD.Data;
using IOTD.Entities;
using System.Security.Cryptography.X509Certificates;
using static IOTD.Controllers.Exams.ExamsModel;

namespace IOTD.Business;

public class MyExam
{
    public MyExam() { }

    public async string uploadExam(ExamUploadModel command)
    {
        var response = "Server bị lỗi ";
        using (DataContext context = new DataContext())
        {
            using (var transaction = await context.Database.BeginTransactionAsync())
            {
                try
                {

                    var existingExam = context.exams.Where(s => s.Title == command.Title).FirstOrDefault();
                    if (existingExam is not null)
                    {
                        return response = "Exams trùng title";
                    }
                    var newExam = new SqlExam();
                    newExam.Title = command.Title;
                    newExam.TimeLimit = command.TimeLimit;
                    newExam.IsReadingExam = command.IsReadingExam;
                    if (newExam.Sections is null)
                    {
                        return response = "Exams phải có sections";
                    }
                    foreach (var section in newExam.Sections)
                    {

                    }


                    await transaction.CommitAsync();
                    return response;
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
