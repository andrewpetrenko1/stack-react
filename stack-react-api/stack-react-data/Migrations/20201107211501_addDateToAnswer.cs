using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace stack_react_data.Migrations
{
    public partial class addDateToAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Answers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "Author", "Date", "QuestionText", "Title", "Views" },
                values: new object[] { 1, "Author 1", new DateTime(2020, 11, 7, 23, 15, 1, 432, DateTimeKind.Local).AddTicks(1755), "Question text", "Question title", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Answers");
        }
    }
}
