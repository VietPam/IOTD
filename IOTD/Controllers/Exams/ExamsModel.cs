using Domain.Entities;

namespace IOTD.Controllers.Exams;

public class ExamsModel
{
    public class ExamUploadModel
    {
        public string Title { get; set; } = string.Empty;

        public int TimeLimit { get; set; } = 40;

        public bool IsReadingExam { get; set; } = true;

        public List<SectionUploadModel> Sections { get; set; } 

    }
    public class SectionUploadModel
    {
        public string Title { get; set; } = string.Empty;

        public string? TextOrMediaLink { get; set; } = null;
        public List<PartUploadModel> Parts { get; set; }

    }
    public class PartUploadModel
    {
        public string Text { get; set; } = string.Empty;

        public string? TextOrMediaLink { get; set; } = null;

        public List<QuestionUploadModel> Questions { get; set; }
    }
    public class QuestionUploadModel
    {
        public string Text { get; set; } = string.Empty;

        public string RightAnswer { get; set; } = string.Empty;

        public List<string> Answers { get; set; } = new List<string>();

    }
}
