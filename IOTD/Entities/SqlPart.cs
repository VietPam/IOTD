using Ielts_online_test_dotnet.Model;
using Ielts_online_test_dotnet.Model.Primitives;
using IOTD.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

[Table("tb_part")]
public class SqlPart :BaseEntity
{
    public string Text { get; set; } = string.Empty;

    public List<SqlQuestion> Questions { get; set; }
    public SqlSection Section { get; set; }
}


