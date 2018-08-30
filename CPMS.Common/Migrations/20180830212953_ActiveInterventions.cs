using Microsoft.EntityFrameworkCore.Migrations;

namespace CPMS.Common.Migrations
{
    public partial class ActiveInterventions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Person",
                table: "JournalEntry",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Interventions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Interventions",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsActive",
                value: true);

            migrationBuilder.InsertData(
                table: "Interventions",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[] { 2, false, "Intervento chiuso" });

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 1,
                column: "Person",
                value: "SM PCi");

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 2,
                column: "Person",
                value: "144");

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 3,
                column: "Person",
                value: "117");

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Person", "Text" },
                values: new object[] { "117", "Messaggio <b>PC fronte</b> 3" });

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 5,
                column: "Person",
                value: "SM PCi");

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 6,
                column: "Person",
                value: "117");

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 7,
                column: "Person",
                value: "117");

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 8,
                column: "Person",
                value: "144");

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 9,
                column: "Person",
                value: "Care team");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Interventions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Person",
                table: "JournalEntry");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Interventions");

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 4,
                column: "Text",
                value: "Messaggio PC fronte 3");
        }
    }
}
