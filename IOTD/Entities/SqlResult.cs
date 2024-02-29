using Domain.Entities;
using Ielts_online_test_dotnet.Model.Primitives;
using IOTD.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ielts_online_test_dotnet.Model;

[Table("tb_result")]
public class SqlResult : BaseEntity
{
    public int RightCount { get; set; } = 0;

    public DateTime TimeBegin { get; set; } = DateTime.UtcNow;

    public DateTime? TimeEnd{ get; set; } = null;

    public SqlExam Exam { get; set; }

    public List<SqlLog> AnswerLogs { get; set; } = new List<SqlLog>();
}
