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
                values: new object[] { 2, "Compagnia XX", 1 });

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
                values: new object[] { 1, null, 9, null, new byte[] { 26, 174, 194, 213, 79, 58, 128, 154, 224, 157, 19, 239, 200, 34, 148, 127, 67, 146, 128, 34, 7, 184, 131, 119, 214, 119, 152, 176, 12, 90, 238, 47, 96, 156, 65, 16, 128, 188, 198, 28, 240, 40, 120, 148, 202, 92, 197, 42, 227, 74, 36, 171, 242, 207, 202, 6, 30, 196, 7, 232, 193, 78, 197, 58 }, new byte[] { 18, 204, 70, 61, 118, 37, 255, 217, 241, 57, 4, 170, 135, 249, 103, 19, 190, 214, 139, 162, 47, 34, 180, 154, 240, 88, 170, 17, 164, 154, 227, 8, 49, 114, 109, 85, 251, 42, 214, 112, 242, 191, 201, 24, 40, 104, 55, 217, 21, 4, 233, 69, 194, 119, 143, 231, 80, 70, 103, 145, 165, 226, 53, 20, 204, 255, 117, 125, 86, 161, 90, 220, 0, 253, 175, 207, 111, 201, 205, 6, 111, 210, 92, 238, 38, 227, 35, 68, 126, 16, 147, 183, 171, 19, 35, 179, 189, 75, 14, 217, 186, 120, 61, 39, 194, 4, 230, 190, 234, 37, 241, 97, 129, 215, 110, 64, 182, 148, 149, 74, 198, 96, 134, 59, 199, 224, 93, 43 }, "admin" });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Name", "ParentId" },
                values: new object[,]
                {
                    { 3, "Sezione aiuto alla condotta 1", 2 },
                    { 6, "Sezione aiuto alla condotta 2", 2 }
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
                values: new object[] { 2, "Nome comandante di compagnia", 2, "", new byte[] { 26, 174, 194, 213, 79, 58, 128, 154, 224, 157, 19, 239, 200, 34, 148, 127, 67, 146, 128, 34, 7, 184, 131, 119, 214, 119, 152, 176, 12, 90, 238, 47, 96, 156, 65, 16, 128, 188, 198, 28, 240, 40, 120, 148, 202, 92, 197, 42, 227, 74, 36, 171, 242, 207, 202, 6, 30, 196, 7, 232, 193, 78, 197, 58 }, new byte[] { 18, 204, 70, 61, 118, 37, 255, 217, 241, 57, 4, 170, 135, 249, 103, 19, 190, 214, 139, 162, 47, 34, 180, 154, 240, 88, 170, 17, 164, 154, 227, 8, 49, 114, 109, 85, 251, 42, 214, 112, 242, 191, 201, 24, 40, 104, 55, 217, 21, 4, 233, 69, 194, 119, 143, 231, 80, 70, 103, 145, 165, 226, 53, 20, 204, 255, 117, 125, 86, 161, 90, 220, 0, 253, 175, 207, 111, 201, 205, 6, 111, 210, 92, 238, 38, 227, 35, 68, 126, 16, 147, 183, 171, 19, 35, 179, 189, 75, 14, 217, 186, 120, 61, 39, 194, 4, 230, 190, 234, 37, 241, 97, 129, 215, 110, 64, 182, 148, 149, 74, 198, 96, 134, 59, 199, 224, 93, 43 }, "ComandanteDiCompagnia-1" });

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
                table: "Users",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 3, "Nome capo sezione", 3, "", new byte[] { 26, 174, 194, 213, 79, 58, 128, 154, 224, 157, 19, 239, 200, 34, 148, 127, 67, 146, 128, 34, 7, 184, 131, 119, 214, 119, 152, 176, 12, 90, 238, 47, 96, 156, 65, 16, 128, 188, 198, 28, 240, 40, 120, 148, 202, 92, 197, 42, 227, 74, 36, 171, 242, 207, 202, 6, 30, 196, 7, 232, 193, 78, 197, 58 }, new byte[] { 18, 204, 70, 61, 118, 37, 255, 217, 241, 57, 4, 170, 135, 249, 103, 19, 190, 214, 139, 162, 47, 34, 180, 154, 240, 88, 170, 17, 164, 154, 227, 8, 49, 114, 109, 85, 251, 42, 214, 112, 242, 191, 201, 24, 40, 104, 55, 217, 21, 4, 233, 69, 194, 119, 143, 231, 80, 70, 103, 145, 165, 226, 53, 20, 204, 255, 117, 125, 86, 161, 90, 220, 0, 253, 175, 207, 111, 201, 205, 6, 111, 210, 92, 238, 38, 227, 35, 68, 126, 16, 147, 183, 171, 19, 35, 179, 189, 75, 14, 217, 186, 120, 61, 39, 194, 4, 230, 190, 234, 37, 241, 97, 129, 215, 110, 64, 182, 148, 149, 74, 198, 96, 134, 59, 199, 224, 93, 43 }, "CapoSezione-1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 4, "Nome capo gruoppo", 4, "", new byte[] { 26, 174, 194, 213, 79, 58, 128, 154, 224, 157, 19, 239, 200, 34, 148, 127, 67, 146, 128, 34, 7, 184, 131, 119, 214, 119, 152, 176, 12, 90, 238, 47, 96, 156, 65, 16, 128, 188, 198, 28, 240, 40, 120, 148, 202, 92, 197, 42, 227, 74, 36, 171, 242, 207, 202, 6, 30, 196, 7, 232, 193, 78, 197, 58 }, new byte[] { 18, 204, 70, 61, 118, 37, 255, 217, 241, 57, 4, 170, 135, 249, 103, 19, 190, 214, 139, 162, 47, 34, 180, 154, 240, 88, 170, 17, 164, 154, 227, 8, 49, 114, 109, 85, 251, 42, 214, 112, 242, 191, 201, 24, 40, 104, 55, 217, 21, 4, 233, 69, 194, 119, 143, 231, 80, 70, 103, 145, 165, 226, 53, 20, 204, 255, 117, 125, 86, 161, 90, 220, 0, 253, 175, 207, 111, 201, 205, 6, 111, 210, 92, 238, 38, 227, 35, 68, 126, 16, 147, 183, 171, 19, 35, 179, 189, 75, 14, 217, 186, 120, 61, 39, 194, 4, 230, 190, 234, 37, 241, 97, 129, 215, 110, 64, 182, 148, 149, 74, 198, 96, 134, 59, 199, 224, 93, 43 }, "CapoGruppo-1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 5, "Nome milite 1", 4, "", new byte[] { 26, 174, 194, 213, 79, 58, 128, 154, 224, 157, 19, 239, 200, 34, 148, 127, 67, 146, 128, 34, 7, 184, 131, 119, 214, 119, 152, 176, 12, 90, 238, 47, 96, 156, 65, 16, 128, 188, 198, 28, 240, 40, 120, 148, 202, 92, 197, 42, 227, 74, 36, 171, 242, 207, 202, 6, 30, 196, 7, 232, 193, 78, 197, 58 }, new byte[] { 18, 204, 70, 61, 118, 37, 255, 217, 241, 57, 4, 170, 135, 249, 103, 19, 190, 214, 139, 162, 47, 34, 180, 154, 240, 88, 170, 17, 164, 154, 227, 8, 49, 114, 109, 85, 251, 42, 214, 112, 242, 191, 201, 24, 40, 104, 55, 217, 21, 4, 233, 69, 194, 119, 143, 231, 80, 70, 103, 145, 165, 226, 53, 20, 204, 255, 117, 125, 86, 161, 90, 220, 0, 253, 175, 207, 111, 201, 205, 6, 111, 210, 92, 238, 38, 227, 35, 68, 126, 16, 147, 183, 171, 19, 35, 179, 189, 75, 14, 217, 186, 120, 61, 39, 194, 4, 230, 190, 234, 37, 241, 97, 129, 215, 110, 64, 182, 148, 149, 74, 198, 96, 134, 59, 199, 224, 93, 43 }, "Milite-1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 6, "Nome milite 2", 4, "", new byte[] { 26, 174, 194, 213, 79, 58, 128, 154, 224, 157, 19, 239, 200, 34, 148, 127, 67, 146, 128, 34, 7, 184, 131, 119, 214, 119, 152, 176, 12, 90, 238, 47, 96, 156, 65, 16, 128, 188, 198, 28, 240, 40, 120, 148, 202, 92, 197, 42, 227, 74, 36, 171, 242, 207, 202, 6, 30, 196, 7, 232, 193, 78, 197, 58 }, new byte[] { 18, 204, 70, 61, 118, 37, 255, 217, 241, 57, 4, 170, 135, 249, 103, 19, 190, 214, 139, 162, 47, 34, 180, 154, 240, 88, 170, 17, 164, 154, 227, 8, 49, 114, 109, 85, 251, 42, 214, 112, 242, 191, 201, 24, 40, 104, 55, 217, 21, 4, 233, 69, 194, 119, 143, 231, 80, 70, 103, 145, 165, 226, 53, 20, 204, 255, 117, 125, 86, 161, 90, 220, 0, 253, 175, 207, 111, 201, 205, 6, 111, 210, 92, 238, 38, 227, 35, 68, 126, 16, 147, 183, 171, 19, 35, 179, 189, 75, 14, 217, 186, 120, 61, 39, 194, 4, 230, 190, 234, 37, 241, 97, 129, 215, 110, 64, 182, 148, 149, 74, 198, 96, 134, 59, 199, 224, 93, 43 }, "Milite-2" });

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

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
