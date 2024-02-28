using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IOTD.Data.Migrations
{
    /// <inheritdoc />
    public partial class addEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_exam",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    TimeLimit = table.Column<int>(type: "integer", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    IsReadingExam = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_exam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tb_section",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    TextOrMediaLink = table.Column<string>(type: "text", nullable: true),
                    ExamId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_section", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_section_tb_exam_ExamId",
                        column: x => x.ExamId,
                        principalTable: "tb_exam",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_result",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeBegin = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AttemptCount = table.Column<int>(type: "integer", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserTakenId = table.Column<long>(type: "bigint", nullable: false),
                    ExamId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_result", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_result_tb_exam_ExamId",
                        column: x => x.ExamId,
                        principalTable: "tb_exam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_result_tb_user_UserTakenId",
                        column: x => x.UserTakenId,
                        principalTable: "tb_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_part",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    SectionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_part", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_part_tb_section_SectionId",
                        column: x => x.SectionId,
                        principalTable: "tb_section",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_question",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: false),
                    RightAnswer = table.Column<string>(type: "text", nullable: false),
                    Answers = table.Column<List<string>>(type: "text[]", nullable: false),
                    PartId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_question_tb_part_PartId",
                        column: x => x.PartId,
                        principalTable: "tb_part",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "tb_answerLogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Answer = table.Column<string>(type: "text", nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    ResultId = table.Column<long>(type: "bigint", nullable: false),
                    QuestionId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_answerLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_answerLogs_tb_question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "tb_question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_answerLogs_tb_result_ResultId",
                        column: x => x.ResultId,
                        principalTable: "tb_result",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_answerLogs_QuestionId",
                table: "tb_answerLogs",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_answerLogs_ResultId",
                table: "tb_answerLogs",
                column: "ResultId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_part_SectionId",
                table: "tb_part",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_question_PartId",
                table: "tb_question",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_result_ExamId",
                table: "tb_result",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_result_UserTakenId",
                table: "tb_result",
                column: "UserTakenId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_section_ExamId",
                table: "tb_section",
                column: "ExamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_answerLogs");

            migrationBuilder.DropTable(
                name: "tb_question");

            migrationBuilder.DropTable(
                name: "tb_result");

            migrationBuilder.DropTable(
                name: "tb_part");

            migrationBuilder.DropTable(
                name: "tb_user");

            migrationBuilder.DropTable(
                name: "tb_section");

            migrationBuilder.DropTable(
                name: "tb_exam");
        }
    }
}
