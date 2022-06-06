using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addedchoicestables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "typeId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "QuestType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_typeId",
                table: "Questions",
                column: "typeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestType_typeId",
                table: "Questions",
                column: "typeId",
                principalTable: "QuestType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestType_typeId",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "QuestType");

            migrationBuilder.DropIndex(
                name: "IX_Questions_typeId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "typeId",
                table: "Questions");
        }
    }
}
