using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class firstmig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Phone_number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profile_image = table.Column<byte>(type: "tinyint", nullable: false),
                    ResumeUser = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    PasswordHashed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Domain",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tech = table.Column<int>(type: "int", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    CandidatId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Experiences_AspNetUsers_CandidatId",
                        column: x => x.CandidatId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "JobOffer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobOfferTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Remote = table.Column<bool>(type: "bit", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    AvailablePlaces = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    EmployerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployerId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Technologies = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOffer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobOffer_AspNetUsers_EmployerId1",
                        column: x => x.EmployerId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employerId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    employerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    candidatId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_Tests_AspNetUsers_employerId1",
                        column: x => x.employerId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Postulations",
                columns: table => new
                {
                    JobOfferId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CandidId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumePost = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postulations", x => new { x.JobOfferId, x.CandidId });
                    table.ForeignKey(
                        name: "FK_Postulations_AspNetUsers_CandidId",
                        column: x => x.CandidId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Postulations_JobOffer_JobOfferId",
                        column: x => x.JobOfferId,
                        principalTable: "JobOffer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    duration = table.Column<int>(type: "int", nullable: true),
                    score = table.Column<float>(type: "real", nullable: true),
                    difficulty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    domain_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    domainId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    typeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    priority = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: true),
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
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    choice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    questionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    isTrue = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
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
                    QcmQuestionId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Choice_questionId",
                table: "Choice",
                column: "questionId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_CandidatId",
                table: "Experiences",
                column: "CandidatId");

            migrationBuilder.CreateIndex(
                name: "IX_JobOffer_EmployerId1",
                table: "JobOffer",
                column: "EmployerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Postulations_CandidId",
                table: "Postulations",
                column: "CandidId");

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
                name: "IX_Tests_employerId1",
                table: "Tests",
                column: "employerId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "Choice");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Postulations");

            migrationBuilder.DropTable(
                name: "QcmResponses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "JobOffer");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Domain");

            migrationBuilder.DropTable(
                name: "QuestType");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
