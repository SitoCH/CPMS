using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CPMS.Common.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Groups_Groups_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                values: new object[] { 1, null, 9, null, "Gq7C1U86gJrgnRPvyCKUf0OSgCIHuIN31neYsAxa7i9gnEEQgLzGHPAoeJTKXMUq40okq/LPygYexAfowU7FOg==", "EsxGPXYl/9nxOQSqh/lnE77Wi6IvIrSa8FiqEaSa4wgxcm1V+yrWcPK/yRgoaDfZFQTpRcJ3j+dQRmeRpeI1FMz/dX1WoVrcAP2vz2/JzQZv0lzuJuMjRH4Qk7erEyOzvUsO2bp4PSfCBOa+6iXxYYHXbkC2lJVKxmCGO8fgXSs=", "admin" });

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
                values: new object[] { 2, "Nome comandante di compagnia", 2, "", "Gq7C1U86gJrgnRPvyCKUf0OSgCIHuIN31neYsAxa7i9gnEEQgLzGHPAoeJTKXMUq40okq/LPygYexAfowU7FOg==", "EsxGPXYl/9nxOQSqh/lnE77Wi6IvIrSa8FiqEaSa4wgxcm1V+yrWcPK/yRgoaDfZFQTpRcJ3j+dQRmeRpeI1FMz/dX1WoVrcAP2vz2/JzQZv0lzuJuMjRH4Qk7erEyOzvUsO2bp4PSfCBOa+6iXxYYHXbkC2lJVKxmCGO8fgXSs=", "ComandanteDiCompagnia-1" });

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
                values: new object[] { 3, "Nome capo sezione", 3, "", "Gq7C1U86gJrgnRPvyCKUf0OSgCIHuIN31neYsAxa7i9gnEEQgLzGHPAoeJTKXMUq40okq/LPygYexAfowU7FOg==", "EsxGPXYl/9nxOQSqh/lnE77Wi6IvIrSa8FiqEaSa4wgxcm1V+yrWcPK/yRgoaDfZFQTpRcJ3j+dQRmeRpeI1FMz/dX1WoVrcAP2vz2/JzQZv0lzuJuMjRH4Qk7erEyOzvUsO2bp4PSfCBOa+6iXxYYHXbkC2lJVKxmCGO8fgXSs=", "CapoSezione-1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 4, "Nome capo gruoppo", 4, "", "Gq7C1U86gJrgnRPvyCKUf0OSgCIHuIN31neYsAxa7i9gnEEQgLzGHPAoeJTKXMUq40okq/LPygYexAfowU7FOg==", "EsxGPXYl/9nxOQSqh/lnE77Wi6IvIrSa8FiqEaSa4wgxcm1V+yrWcPK/yRgoaDfZFQTpRcJ3j+dQRmeRpeI1FMz/dX1WoVrcAP2vz2/JzQZv0lzuJuMjRH4Qk7erEyOzvUsO2bp4PSfCBOa+6iXxYYHXbkC2lJVKxmCGO8fgXSs=", "CapoGruppo-1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 5, "Nome milite 1", 4, "", "Gq7C1U86gJrgnRPvyCKUf0OSgCIHuIN31neYsAxa7i9gnEEQgLzGHPAoeJTKXMUq40okq/LPygYexAfowU7FOg==", "EsxGPXYl/9nxOQSqh/lnE77Wi6IvIrSa8FiqEaSa4wgxcm1V+yrWcPK/yRgoaDfZFQTpRcJ3j+dQRmeRpeI1FMz/dX1WoVrcAP2vz2/JzQZv0lzuJuMjRH4Qk7erEyOzvUsO2bp4PSfCBOa+6iXxYYHXbkC2lJVKxmCGO8fgXSs=", "Milite-1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 6, "Nome milite 2", 4, "", "Gq7C1U86gJrgnRPvyCKUf0OSgCIHuIN31neYsAxa7i9gnEEQgLzGHPAoeJTKXMUq40okq/LPygYexAfowU7FOg==", "EsxGPXYl/9nxOQSqh/lnE77Wi6IvIrSa8FiqEaSa4wgxcm1V+yrWcPK/yRgoaDfZFQTpRcJ3j+dQRmeRpeI1FMz/dX1WoVrcAP2vz2/JzQZv0lzuJuMjRH4Qk7erEyOzvUsO2bp4PSfCBOa+6iXxYYHXbkC2lJVKxmCGO8fgXSs=", "Milite-2" });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ParentId",
                table: "Groups",
                column: "ParentId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId",
                table: "Users",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JournalEntry");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "JournalEntryChannel");

            migrationBuilder.DropTable(
                name: "Journal");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Interventions");
        }
    }
}
