using Domain.Entities;
using Ielts_online_test_dotnet.Model.Primitives;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ielts_online_test_dotnet.Model;

[Table("tb_answerLogs")]
public class SqlLogs :BaseEntity
{
    public string Answer { get; set; } = string.Empty;

    public bool IsCorrect { get; set; } // compare with RightAnswer.Text

    public SqlResult Result { get; set; }

    public SqlQuestion Question { get; set; }


}
