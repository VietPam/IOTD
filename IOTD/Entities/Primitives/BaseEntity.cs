using System.ComponentModel.DataAnnotations;

namespace Ielts_online_test_dotnet.Model.Primitives;

public class BaseEntity
{
    [Key]
    public long Id { get; set; } = DateTime.UtcNow.Ticks / 100;
}
