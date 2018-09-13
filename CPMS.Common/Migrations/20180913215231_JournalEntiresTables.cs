using Microsoft.EntityFrameworkCore.Migrations;

namespace CPMS.Common.Migrations
{
    public partial class JournalEntiresTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntry_JournalEntryChannels_JournalEntryChannelId",
                table: "JournalEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntry_Journals_JournalId",
                table: "JournalEntry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JournalEntry",
                table: "JournalEntry");

            migrationBuilder.RenameTable(
                name: "JournalEntry",
                newName: "JournalEntries");

            migrationBuilder.RenameIndex(
                name: "IX_JournalEntry_JournalId",
                table: "JournalEntries",
                newName: "IX_JournalEntries_JournalId");

            migrationBuilder.RenameIndex(
                name: "IX_JournalEntry_JournalEntryChannelId",
                table: "JournalEntries",
                newName: "IX_JournalEntries_JournalEntryChannelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JournalEntries",
                table: "JournalEntries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntries_JournalEntryChannels_JournalEntryChannelId",
                table: "JournalEntries",
                column: "JournalEntryChannelId",
                principalTable: "JournalEntryChannels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntries_Journals_JournalId",
                table: "JournalEntries",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntries_JournalEntryChannels_JournalEntryChannelId",
                table: "JournalEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntries_Journals_JournalId",
                table: "JournalEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JournalEntries",
                table: "JournalEntries");

            migrationBuilder.RenameTable(
                name: "JournalEntries",
                newName: "JournalEntry");

            migrationBuilder.RenameIndex(
                name: "IX_JournalEntries_JournalId",
                table: "JournalEntry",
                newName: "IX_JournalEntry_JournalId");

            migrationBuilder.RenameIndex(
                name: "IX_JournalEntries_JournalEntryChannelId",
                table: "JournalEntry",
                newName: "IX_JournalEntry_JournalEntryChannelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JournalEntry",
                table: "JournalEntry",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntry_JournalEntryChannels_JournalEntryChannelId",
                table: "JournalEntry",
                column: "JournalEntryChannelId",
                principalTable: "JournalEntryChannels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntry_Journals_JournalId",
                table: "JournalEntry",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
