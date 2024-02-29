using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOTD.Data.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_result_tb_user_UserTakenId",
                table: "tb_result");

            migrationBuilder.DropIndex(
                name: "IX_tb_result_UserTakenId",
                table: "tb_result");

            migrationBuilder.DropColumn(
                name: "UserTakenId",
                table: "tb_result");

            migrationBuilder.AddColumn<long>(
                name: "SqlUserId",
                table: "tb_result",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_result_SqlUserId",
                table: "tb_result",
                column: "SqlUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_result_tb_user_SqlUserId",
                table: "tb_result",
                column: "SqlUserId",
                principalTable: "tb_user",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_result_tb_user_SqlUserId",
                table: "tb_result");

            migrationBuilder.DropIndex(
                name: "IX_tb_result_SqlUserId",
                table: "tb_result");

            migrationBuilder.DropColumn(
                name: "SqlUserId",
                table: "tb_result");

            migrationBuilder.AddColumn<long>(
                name: "UserTakenId",
                table: "tb_result",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_tb_result_UserTakenId",
                table: "tb_result",
                column: "UserTakenId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_result_tb_user_UserTakenId",
                table: "tb_result",
                column: "UserTakenId",
                principalTable: "tb_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
