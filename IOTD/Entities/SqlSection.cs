using Domain.Entities;
using Ielts_online_test_dotnet.Model.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IOTD.Entities;

[Table("tb_section")]
public class SqlSection : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string? TextOrMediaLink { get; set; } = null;

    public SqlExam? Exam { get; set; } = null;

    public List<SqlPart> Parts { get; set; } = new List<SqlPart>();
}
