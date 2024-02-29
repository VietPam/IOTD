﻿// <auto-generated />
using System;
using System.Collections.Generic;
using IOTD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IOTD.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240229162019_update1")]
    partial class update1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.SqlPart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("SectionId")
                        .HasColumnType("bigint");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("tb_part");
                });

            modelBuilder.Entity("Domain.Entities.SqlQuestion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<List<string>>("Answers")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<bool>("IsMultichoice")
                        .HasColumnType("boolean");

                    b.Property<long?>("PartId")
                        .HasColumnType("bigint");

                    b.Property<string>("RightAnswer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PartId");

                    b.ToTable("tb_question");
                });

            modelBuilder.Entity("IOTD.Entities.SqlExam", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsReadingExam")
                        .HasColumnType("boolean");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TimeLimit")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("tb_exam");
                });

            modelBuilder.Entity("IOTD.Entities.SqlSection", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("ExamId")
                        .HasColumnType("bigint");

                    b.Property<string>("TextOrMediaLink")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("tb_section");
                });

            modelBuilder.Entity("Ielts_online_test_dotnet.Model.SqlLog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("boolean");

                    b.Property<long?>("QuestionId")
                        .HasColumnType("bigint");

                    b.Property<long>("ResultId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("ResultId");

                    b.ToTable("tb_answerLogs");
                });

            modelBuilder.Entity("Ielts_online_test_dotnet.Model.SqlResult", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ExamId")
                        .HasColumnType("bigint");

                    b.Property<int>("RightCount")
                        .HasColumnType("integer");

                    b.Property<DateTime>("TimeBegin")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("TimeEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("UserTakenId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.HasIndex("UserTakenId");

                    b.ToTable("tb_result");
                });

            modelBuilder.Entity("Ielts_online_test_dotnet.Model.SqlUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("tb_user");
                });

            modelBuilder.Entity("Domain.Entities.SqlPart", b =>
                {
                    b.HasOne("IOTD.Entities.SqlSection", "Section")
                        .WithMany("Parts")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");
                });

            modelBuilder.Entity("Domain.Entities.SqlQuestion", b =>
                {
                    b.HasOne("Domain.Entities.SqlPart", "Part")
                        .WithMany("Questions")
                        .HasForeignKey("PartId");

                    b.Navigation("Part");
                });

            modelBuilder.Entity("IOTD.Entities.SqlSection", b =>
                {
                    b.HasOne("IOTD.Entities.SqlExam", "Exam")
                        .WithMany("Sections")
                        .HasForeignKey("ExamId");

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("Ielts_online_test_dotnet.Model.SqlLog", b =>
                {
                    b.HasOne("Domain.Entities.SqlQuestion", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId");

                    b.HasOne("Ielts_online_test_dotnet.Model.SqlResult", "Result")
                        .WithMany("AnswerLogs")
                        .HasForeignKey("ResultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("Result");
                });

            modelBuilder.Entity("Ielts_online_test_dotnet.Model.SqlResult", b =>
                {
                    b.HasOne("IOTD.Entities.SqlExam", "Exam")
                        .WithMany()
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ielts_online_test_dotnet.Model.SqlUser", "UserTaken")
                        .WithMany("ExamsTaken")
                        .HasForeignKey("UserTakenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("UserTaken");
                });

            modelBuilder.Entity("Domain.Entities.SqlPart", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("IOTD.Entities.SqlExam", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("IOTD.Entities.SqlSection", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("Ielts_online_test_dotnet.Model.SqlResult", b =>
                {
                    b.Navigation("AnswerLogs");
                });

            modelBuilder.Entity("Ielts_online_test_dotnet.Model.SqlUser", b =>
                {
                    b.Navigation("ExamsTaken");
                });
#pragma warning restore 612, 618
        }
    }
}