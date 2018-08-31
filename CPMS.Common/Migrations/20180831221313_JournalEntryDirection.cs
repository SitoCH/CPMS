using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CPMS.Common.Migrations
{
    public partial class JournalEntryDirection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Direction",
                table: "JournalEntry",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 3,
                column: "Direction",
                value: 1);

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 7,
                column: "Direction",
                value: 1);

            migrationBuilder.InsertData(
                table: "JournalEntry",
                columns: new[] { "Id", "DateTime", "Direction", "JournalEntryChannelId", "JournalId", "Person", "Text" },
                values: new object[] { 10, new DateTime(2018, 2, 2, 8, 50, 0, 0, DateTimeKind.Unspecified), 1, 2, 2, "Care team", "<h1>Titolo</h1><div><br></div><div>Testo messaggio.</div><div><span style=\"color: rgb(230, 0, 0);\">Informazioni importanti:</span></div><div><br></div><ol><li>Info 1</li><li>Info 2</li><li>Info 3</li></ol><div><br></div><div><br></div>" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "Direction",
                table: "JournalEntry");
        }
    }
}
