using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class QcmQuestionTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Domain",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profile_image = table.Column<byte>(type: "tinyint", nullable: false),
                    passwordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    resume = table.Column<byte>(type: "tinyint", nullable: true),
                    companyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    companyWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    test = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experience",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experience_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    candidatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_Tests_Users_employerId",
                        column: x => x.employerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Technologie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    label = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    field = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CandidatId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Technologie_Experience_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experience",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Technologie_Users_CandidatId",
                        column: x => x.CandidatId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duration = table.Column<int>(type: "int", nullable: true),
                    score = table.Column<float>(type: "real", nullable: true),
                    difficulty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    domain_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    domainId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    typeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    priority = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Domain_domainId",
                        column: x => x.domainId,
                        principalTable: "Domain",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_QuestType_typeId",
                        column: x => x.typeId,
                        principalTable: "QuestType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Questions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "TestId");
                });

            migrationBuilder.CreateTable(
                name: "Choice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    choice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    questionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    isTrue = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Choice_Questions_questionId",
                        column: x => x.questionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QcmResponses",
                columns: table => new
                {
                    text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isTrue = table.Column<bool>(type: "bit", nullable: false),
                    QcmQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_QcmResponses_Questions_QcmQuestionId",
                        column: x => x.QcmQuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Choice_questionId",
                table: "Choice",
                column: "questionId");

            migrationBuilder.CreateIndex(
                name: "IX_Experience_UserId",
                table: "Experience",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_QcmResponses_QcmQuestionId",
                table: "QcmResponses",
                column: "QcmQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_domainId",
                table: "Questions",
                column: "domainId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_typeId",
                table: "Questions",
                column: "typeId");

            migrationBuilder.CreateIndex(
                name: "IX_Technologie_CandidatId",
                table: "Technologie",
                column: "CandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_Technologie_ExperienceId",
                table: "Technologie",
                column: "ExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_employerId",
                table: "Tests",
                column: "employerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choice");

            migrationBuilder.DropTable(
                name: "QcmResponses");

            migrationBuilder.DropTable(
                name: "Technologie");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Experience");

            migrationBuilder.DropTable(
                name: "Domain");

            migrationBuilder.DropTable(
                name: "QuestType");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
