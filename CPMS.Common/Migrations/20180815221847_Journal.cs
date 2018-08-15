using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CPMS.Common.Migrations
{
    public partial class Journal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interventions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interventions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntryChannel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntryChannel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Journal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    InterventionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Journal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Journal_Interventions_InterventionId",
                        column: x => x.InterventionId,
                        principalTable: "Interventions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JournalEntry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    JournalId = table.Column<int>(nullable: false),
                    JournalEntryChannelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JournalEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JournalEntry_JournalEntryChannel_JournalEntryChannelId",
                        column: x => x.JournalEntryChannelId,
                        principalTable: "JournalEntryChannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JournalEntry_Journal_JournalId",
                        column: x => x.JournalId,
                        principalTable: "Journal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, "Regione X", null },
                    { 2, "Compagnia XX", null },
                    { 9, "Ospiti", null }
                });

            migrationBuilder.InsertData(
                table: "Interventions",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Intervento demo" });

            migrationBuilder.InsertData(
                table: "JournalEntryChannel",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "fa-phone", "Phone" },
                    { 2, "fa-mobile", "Mobile" },
                    { 3, "fa-envelope ", "E-mail" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 3, "Sezione aiuto alla condotta 1", 2 },
                    { 6, "Sezione aiuto alla condotta 2", 2 }
                });

            migrationBuilder.InsertData(
                table: "Journal",
                columns: new[] { "Id", "InterventionId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "PC fronte" },
                    { 2, 1, "PC retro" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[,]
                {
                    { 2, "Nome comandante di compagnia", 2, "", new byte[] { 46, 199, 55, 151, 127, 235, 238, 33, 92, 110, 237, 30, 132, 246, 56, 201, 4, 61, 129, 62, 141, 146, 205, 135, 230, 234, 106, 120, 16, 50, 248, 206, 244, 13, 34, 44, 98, 190, 136, 66, 253, 165, 209, 82, 248, 67, 239, 248, 18, 131, 154, 250, 44, 93, 212, 221, 16, 255, 109, 201, 90, 226, 244, 192 }, new byte[] { 248, 107, 74, 122, 139, 216, 237, 219, 60, 9, 113, 180, 128, 79, 196, 90, 191, 146, 119, 54, 191, 149, 43, 175, 115, 101, 161, 13, 104, 204, 106, 47, 143, 127, 18, 99, 15, 240, 177, 35, 132, 126, 52, 65, 104, 139, 200, 122, 35, 107, 28, 198, 3, 129, 184, 75, 22, 202, 92, 18, 141, 29, 162, 175, 6, 62, 38, 46, 98, 189, 0, 250, 124, 69, 144, 158, 58, 223, 244, 228, 73, 105, 194, 78, 173, 224, 76, 244, 198, 131, 60, 78, 148, 155, 128, 78, 99, 8, 177, 103, 178, 243, 127, 156, 5, 239, 169, 104, 233, 193, 98, 87, 180, 27, 125, 205, 219, 218, 70, 46, 136, 147, 224, 218, 233, 130, 243, 120 }, "ComandanteDiCompagnia-1" },
                    { 1, null, 9, null, new byte[] { 46, 199, 55, 151, 127, 235, 238, 33, 92, 110, 237, 30, 132, 246, 56, 201, 4, 61, 129, 62, 141, 146, 205, 135, 230, 234, 106, 120, 16, 50, 248, 206, 244, 13, 34, 44, 98, 190, 136, 66, 253, 165, 209, 82, 248, 67, 239, 248, 18, 131, 154, 250, 44, 93, 212, 221, 16, 255, 109, 201, 90, 226, 244, 192 }, new byte[] { 248, 107, 74, 122, 139, 216, 237, 219, 60, 9, 113, 180, 128, 79, 196, 90, 191, 146, 119, 54, 191, 149, 43, 175, 115, 101, 161, 13, 104, 204, 106, 47, 143, 127, 18, 99, 15, 240, 177, 35, 132, 126, 52, 65, 104, 139, 200, 122, 35, 107, 28, 198, 3, 129, 184, 75, 22, 202, 92, 18, 141, 29, 162, 175, 6, 62, 38, 46, 98, 189, 0, 250, 124, 69, 144, 158, 58, 223, 244, 228, 73, 105, 194, 78, 173, 224, 76, 244, 198, 131, 60, 78, 148, 155, 128, 78, 99, 8, 177, 103, 178, 243, 127, 156, 5, 239, 169, 104, 233, 193, 98, 87, 180, 27, 125, 205, 219, 218, 70, 46, 136, 147, 224, 218, 233, 130, 243, 120 }, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 4, "Gruppo 1", 3 },
                    { 5, "Gruppo 2", 3 },
                    { 7, "Gruppo 1", 6 },
                    { 8, "Gruppo 2", 6 }
                });

            migrationBuilder.InsertData(
                table: "JournalEntry",
                columns: new[] { "Id", "DateTime", "JournalEntryChannelId", "JournalId", "Text" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 2, 2, 8, 30, 0, 0, DateTimeKind.Unspecified), 2, 1, "Inizio esercizio" },
                    { 2, new DateTime(2018, 2, 2, 8, 36, 0, 0, DateTimeKind.Unspecified), 1, 1, "Messaggio PC fronte 1" },
                    { 3, new DateTime(2018, 2, 2, 8, 42, 0, 0, DateTimeKind.Unspecified), 1, 1, "Messaggio PC fronte 2" },
                    { 4, new DateTime(2018, 2, 2, 8, 45, 0, 0, DateTimeKind.Unspecified), 3, 1, "Messaggio PC fronte 3" },
                    { 6, new DateTime(2018, 2, 2, 8, 38, 0, 0, DateTimeKind.Unspecified), 2, 1, "Messaggio PC retro 1" },
                    { 7, new DateTime(2018, 2, 2, 8, 40, 0, 0, DateTimeKind.Unspecified), 1, 1, "Messaggio PC retro 2" },
                    { 8, new DateTime(2018, 2, 2, 8, 40, 0, 0, DateTimeKind.Unspecified), 1, 1, "Messaggio PC retro 3" },
                    { 9, new DateTime(2018, 2, 2, 8, 47, 0, 0, DateTimeKind.Unspecified), 2, 1, "Messaggio PC retro 4" },
                    { 5, new DateTime(2018, 2, 2, 8, 25, 0, 0, DateTimeKind.Unspecified), 2, 2, "Inizio esercizio" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 3, "Nome capo sezione", 3, "", new byte[] { 46, 199, 55, 151, 127, 235, 238, 33, 92, 110, 237, 30, 132, 246, 56, 201, 4, 61, 129, 62, 141, 146, 205, 135, 230, 234, 106, 120, 16, 50, 248, 206, 244, 13, 34, 44, 98, 190, 136, 66, 253, 165, 209, 82, 248, 67, 239, 248, 18, 131, 154, 250, 44, 93, 212, 221, 16, 255, 109, 201, 90, 226, 244, 192 }, new byte[] { 248, 107, 74, 122, 139, 216, 237, 219, 60, 9, 113, 180, 128, 79, 196, 90, 191, 146, 119, 54, 191, 149, 43, 175, 115, 101, 161, 13, 104, 204, 106, 47, 143, 127, 18, 99, 15, 240, 177, 35, 132, 126, 52, 65, 104, 139, 200, 122, 35, 107, 28, 198, 3, 129, 184, 75, 22, 202, 92, 18, 141, 29, 162, 175, 6, 62, 38, 46, 98, 189, 0, 250, 124, 69, 144, 158, 58, 223, 244, 228, 73, 105, 194, 78, 173, 224, 76, 244, 198, 131, 60, 78, 148, 155, 128, 78, 99, 8, 177, 103, 178, 243, 127, 156, 5, 239, 169, 104, 233, 193, 98, 87, 180, 27, 125, 205, 219, 218, 70, 46, 136, 147, 224, 218, 233, 130, 243, 120 }, "CapoSezione-1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 4, "Nome capo gruoppo", 4, "", new byte[] { 46, 199, 55, 151, 127, 235, 238, 33, 92, 110, 237, 30, 132, 246, 56, 201, 4, 61, 129, 62, 141, 146, 205, 135, 230, 234, 106, 120, 16, 50, 248, 206, 244, 13, 34, 44, 98, 190, 136, 66, 253, 165, 209, 82, 248, 67, 239, 248, 18, 131, 154, 250, 44, 93, 212, 221, 16, 255, 109, 201, 90, 226, 244, 192 }, new byte[] { 248, 107, 74, 122, 139, 216, 237, 219, 60, 9, 113, 180, 128, 79, 196, 90, 191, 146, 119, 54, 191, 149, 43, 175, 115, 101, 161, 13, 104, 204, 106, 47, 143, 127, 18, 99, 15, 240, 177, 35, 132, 126, 52, 65, 104, 139, 200, 122, 35, 107, 28, 198, 3, 129, 184, 75, 22, 202, 92, 18, 141, 29, 162, 175, 6, 62, 38, 46, 98, 189, 0, 250, 124, 69, 144, 158, 58, 223, 244, 228, 73, 105, 194, 78, 173, 224, 76, 244, 198, 131, 60, 78, 148, 155, 128, 78, 99, 8, 177, 103, 178, 243, 127, 156, 5, 239, 169, 104, 233, 193, 98, 87, 180, 27, 125, 205, 219, 218, 70, 46, 136, 147, 224, 218, 233, 130, 243, 120 }, "CapoGruppo-1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 5, "Nome milite 1", 4, "", new byte[] { 46, 199, 55, 151, 127, 235, 238, 33, 92, 110, 237, 30, 132, 246, 56, 201, 4, 61, 129, 62, 141, 146, 205, 135, 230, 234, 106, 120, 16, 50, 248, 206, 244, 13, 34, 44, 98, 190, 136, 66, 253, 165, 209, 82, 248, 67, 239, 248, 18, 131, 154, 250, 44, 93, 212, 221, 16, 255, 109, 201, 90, 226, 244, 192 }, new byte[] { 248, 107, 74, 122, 139, 216, 237, 219, 60, 9, 113, 180, 128, 79, 196, 90, 191, 146, 119, 54, 191, 149, 43, 175, 115, 101, 161, 13, 104, 204, 106, 47, 143, 127, 18, 99, 15, 240, 177, 35, 132, 126, 52, 65, 104, 139, 200, 122, 35, 107, 28, 198, 3, 129, 184, 75, 22, 202, 92, 18, 141, 29, 162, 175, 6, 62, 38, 46, 98, 189, 0, 250, 124, 69, 144, 158, 58, 223, 244, 228, 73, 105, 194, 78, 173, 224, 76, 244, 198, 131, 60, 78, 148, 155, 128, 78, 99, 8, 177, 103, 178, 243, 127, 156, 5, 239, 169, 104, 233, 193, 98, 87, 180, 27, 125, 205, 219, 218, 70, 46, 136, 147, 224, 218, 233, 130, 243, 120 }, "Milite-1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 6, "Nome milite 2", 4, "", new byte[] { 46, 199, 55, 151, 127, 235, 238, 33, 92, 110, 237, 30, 132, 246, 56, 201, 4, 61, 129, 62, 141, 146, 205, 135, 230, 234, 106, 120, 16, 50, 248, 206, 244, 13, 34, 44, 98, 190, 136, 66, 253, 165, 209, 82, 248, 67, 239, 248, 18, 131, 154, 250, 44, 93, 212, 221, 16, 255, 109, 201, 90, 226, 244, 192 }, new byte[] { 248, 107, 74, 122, 139, 216, 237, 219, 60, 9, 113, 180, 128, 79, 196, 90, 191, 146, 119, 54, 191, 149, 43, 175, 115, 101, 161, 13, 104, 204, 106, 47, 143, 127, 18, 99, 15, 240, 177, 35, 132, 126, 52, 65, 104, 139, 200, 122, 35, 107, 28, 198, 3, 129, 184, 75, 22, 202, 92, 18, 141, 29, 162, 175, 6, 62, 38, 46, 98, 189, 0, 250, 124, 69, 144, 158, 58, 223, 244, 228, 73, 105, 194, 78, 173, 224, 76, 244, 198, 131, 60, 78, 148, 155, 128, 78, 99, 8, 177, 103, 178, 243, 127, 156, 5, 239, 169, 104, 233, 193, 98, 87, 180, 27, 125, 205, 219, 218, 70, 46, 136, 147, 224, 218, 233, 130, 243, 120 }, "Milite-2" });

            migrationBuilder.CreateIndex(
                name: "IX_Journal_InterventionId",
                table: "Journal",
                column: "InterventionId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_JournalEntryChannelId",
                table: "JournalEntry",
                column: "JournalEntryChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_JournalEntry_JournalId",
                table: "JournalEntry",
                column: "JournalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalEntry");

            migrationBuilder.DropTable(
                name: "JournalEntryChannel");

            migrationBuilder.DropTable(
                name: "Journal");

            migrationBuilder.DropTable(
                name: "Interventions");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
