using Domain.Entities;
using Ielts_online_test_dotnet.Model;
using IOTD.Entities;
using Microsoft.EntityFrameworkCore;

namespace IOTD.Data;

public class DataContext : DbContext
{
    // add-migration addEntity -OutputDir Data\Migrations
    public DbSet<SqlUser> users { get; set; }
    public DbSet<SqlExam> exams { get; set; }
    public DbSet<SqlPart> parts { get; set; }
    public DbSet<SqlSection> sections { get; set; }
    public DbSet<SqlQuestion> questions { get; set; }
    public DbSet<SqlResult> results { get; set; }
    public DbSet<SqlLogs> logs { get; set; }

    public static string configSql = "Host=localhost:5434;Database=IOTD1;Username=postgres;Password=12345678";
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(configSql);
    }
}
