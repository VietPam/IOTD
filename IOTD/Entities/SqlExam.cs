using Ielts_online_test_dotnet.Model.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IOTD.Entities;

[Table("tb_exam")]
public class SqlExam :BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public int TimeLimit { get; set; } = 40;

    public string Slug { get; set; } = string.Empty;

    public bool IsReadingExam { get; set; } = true;

    public List<SqlSection>? Sections { get; set; } =new List<SqlSection>();

}
