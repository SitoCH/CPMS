using Microsoft.EntityFrameworkCore.Migrations;

namespace CPMS.Common.Migrations
{
    public partial class JournalEntitiesRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "JournalEntry",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Person",
                table: "JournalEntry",
                newName: "Message");

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Message", "Name" },
                values: new object[] { "Inizio esercizio", "SM PCi" });

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Message", "Name" },
                values: new object[] { "Messaggio PC fronte 1", "144" });

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Message", "Name" },
                values: new object[] { "Messaggio PC fronte 2", "117" });

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Message", "Name" },
                values: new object[] { "Messaggio <b>PC fronte</b> 3", "117" });

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Message", "Name" },
                values: new object[] { "Inizio esercizio", "SM PCi" });

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Message", "Name" },
                values: new object[] { "Messaggio PC retro 1", "117" });

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Message", "Name" },
                values: new object[] { "Messaggio PC retro 2", "117" });

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Message", "Name" },
                values: new object[] { "Messaggio PC retro 3", "144" });

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Message", "Name" },
                values: new object[] { "Messaggio PC retro 4", "Care team" });

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Message", "Name" },
                values: new object[] { "<h1>Titolo</h1><div><br></div><div>Testo messaggio.</div><div><span style=\"color: rgb(230, 0, 0);\">Informazioni importanti:</span></div><div><br></div><ol><li>Info 1</li><li>Info 2</li><li>Info 3</li></ol><div><br></div><div><br></div>", "Care team" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "JournalEntry",
                newName: "Text");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "JournalEntry",
                newName: "Person");

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Person", "Text" },
                values: new object[] { "SM PCi", "Inizio esercizio" });

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Person", "Text" },
                values: new object[] { "144", "Messaggio PC fronte 1" });

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Person", "Text" },
                values: new object[] { "117", "Messaggio PC fronte 2" });

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
                columns: new[] { "Person", "Text" },
                values: new object[] { "SM PCi", "Inizio esercizio" });

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Person", "Text" },
                values: new object[] { "117", "Messaggio PC retro 1" });

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Person", "Text" },
                values: new object[] { "117", "Messaggio PC retro 2" });

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Person", "Text" },
                values: new object[] { "144", "Messaggio PC retro 3" });

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Person", "Text" },
                values: new object[] { "Care team", "Messaggio PC retro 4" });

            migrationBuilder.UpdateData(
                table: "JournalEntry",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Person", "Text" },
                values: new object[] { "Care team", "<h1>Titolo</h1><div><br></div><div>Testo messaggio.</div><div><span style=\"color: rgb(230, 0, 0);\">Informazioni importanti:</span></div><div><br></div><ol><li>Info 1</li><li>Info 2</li><li>Info 3</li></ol><div><br></div><div><br></div>" });
        }
    }
}
