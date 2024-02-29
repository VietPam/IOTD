using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOTD.Data.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_answerLogs_tb_question_QuestionId",
                table: "tb_answerLogs");

            migrationBuilder.RenameColumn(
                name: "AttemptCount",
                table: "tb_result",
                newName: "RightCount");

            migrationBuilder.AlterColumn<long>(
                name: "QuestionId",
                table: "tb_answerLogs",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_answerLogs_tb_question_QuestionId",
                table: "tb_answerLogs",
                column: "QuestionId",
                principalTable: "tb_question",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_answerLogs_tb_question_QuestionId",
                table: "tb_answerLogs");

            migrationBuilder.RenameColumn(
                name: "RightCount",
                table: "tb_result",
                newName: "AttemptCount");

            migrationBuilder.AlterColumn<long>(
                name: "QuestionId",
                table: "tb_answerLogs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_answerLogs_tb_question_QuestionId",
                table: "tb_answerLogs",
                column: "QuestionId",
                principalTable: "tb_question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
