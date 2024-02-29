using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOTD.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateSqlquestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFillIn",
                table: "tb_question",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFillIn",
                table: "tb_question");
        }
    }
}
