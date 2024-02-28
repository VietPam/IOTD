using Ielts_online_test_dotnet.Model.Primitives;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ielts_online_test_dotnet.Model;


[Table("tb_user")]
public class SqlUser :BaseEntity
{
    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = "123456";

    public List<SqlResult>? ExamsTaken { get; set; } = null;
}
