namespace IOTD.Controllers.Result;

public class ResultsModel
{
    public class ResultSubmitModel
    {
        public string TimeBegin { get; set; } = string.Empty;
        public string TimeEnd { get; set; } = string.Empty;
        public List<LogsSubmitModel>? Logs { get; set; } = new List<LogsSubmitModel>();
    }
    public class LogsSubmitModel
    {
        public long IdQuestion { get; set; }
        public string Answer { get; set; } = string.Empty;
    }
}
