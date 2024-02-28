using Ielts_online_test_dotnet.Model.Primitives;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;


[Table("tb_question")]
public class SqlQuestion  : BaseEntity
{
    public string Text { get; set; } = string.Empty; 

    public string RightAnswer { get; set; } = string.Empty;

    public List<string> Answers { get; set; } = new List<string> ();

    public virtual SqlPart? Part { get; set; }
}
