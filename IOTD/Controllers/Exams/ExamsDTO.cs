using static IOTD.Controllers.Exams.ExamsModel;

namespace IOTD.Controllers.Exams;

public class ExamsDTO
{
    public class ExamGetDTO
    {
        public string Title { get; set; } = string.Empty;

        public int TimeLimit { get; set; } = 40;

        public bool IsReadingExam { get; set; } = true;

        public List<SectionGetDTO> Sections { get; set; } = new List<SectionGetDTO>();
    }
    public class SectionGetDTO
    {
        public string Title { get; set; } = string.Empty;

        public string? TextOrMediaLink { get; set; } = null;

        public List<PartGetDTO> Parts { get; set; } = new List<PartGetDTO>();
    }
    public class PartGetDTO
    {
        public string Text { get; set; } = string.Empty;

        public string? TextOrMediaLink { get; set; } = null;

        public List<QuestionGetDTO> Questions { get; set; } = new List<QuestionGetDTO>();
    }

    public class QuestionGetDTO
    {
        public string Text { get; set; } = string.Empty;

        public List<string> Answers { get; set; } = new List<string>();
    }
}
