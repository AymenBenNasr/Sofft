using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class updateddomainclass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choice_Questions_questionId",
                table: "Choice");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Domain_domainId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestType_typeId",
                table: "Questions");

            migrationBuilder.AlterColumn<Guid>(
                name: "typeId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "domainId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "questionId",
                table: "Choice",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "choice",
                table: "Choice",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Choice_Questions_questionId",
                table: "Choice",
                column: "questionId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Domain_domainId",
                table: "Questions",
                column: "domainId",
                principalTable: "Domain",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestType_typeId",
                table: "Questions",
                column: "typeId",
                principalTable: "QuestType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choice_Questions_questionId",
                table: "Choice");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Domain_domainId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestType_typeId",
                table: "Questions");

            migrationBuilder.AlterColumn<Guid>(
                name: "typeId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "domainId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "questionId",
                table: "Choice",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "choice",
                table: "Choice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Choice_Questions_questionId",
                table: "Choice",
                column: "questionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Domain_domainId",
                table: "Questions",
                column: "domainId",
                principalTable: "Domain",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestType_typeId",
                table: "Questions",
                column: "typeId",
                principalTable: "QuestType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
