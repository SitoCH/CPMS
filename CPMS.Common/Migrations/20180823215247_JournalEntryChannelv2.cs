using Microsoft.EntityFrameworkCore.Migrations;

namespace CPMS.Common.Migrations
{
    public partial class JournalEntryChannelv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 6,
                column: "JournalId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 7,
                column: "JournalId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 8,
                column: "JournalId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 9,
                column: "JournalId",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 6,
                column: "JournalId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 7,
                column: "JournalId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 8,
                column: "JournalId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 9,
                column: "JournalId",
                value: 1);
        }
    }
}
