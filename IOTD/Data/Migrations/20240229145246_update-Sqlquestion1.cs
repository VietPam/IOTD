using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOTD.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateSqlquestion1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsFillIn",
                table: "tb_question",
                newName: "IsMultichoice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsMultichoice",
                table: "tb_question",
                newName: "IsFillIn");
        }
    }
}
