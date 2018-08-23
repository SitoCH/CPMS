using Microsoft.EntityFrameworkCore.Migrations;

namespace CPMS.Common.Migrations
{
    public partial class JournalEntryChannel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntry_JournalEntryChannel_JournalEntryChannelId",
                table: "JournalEntry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JournalEntryChannel",
                table: "JournalEntryChannel");

            migrationBuilder.RenameTable(
                name: "JournalEntryChannel",
                newName: "JournalEntryChannels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JournalEntryChannels",
                table: "JournalEntryChannels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntry_JournalEntryChannels_JournalEntryChannelId",
                table: "JournalEntry",
                column: "JournalEntryChannelId",
                principalTable: "JournalEntryChannels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntry_JournalEntryChannels_JournalEntryChannelId",
                table: "JournalEntry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JournalEntryChannels",
                table: "JournalEntryChannels");

            migrationBuilder.RenameTable(
                name: "JournalEntryChannels",
                newName: "JournalEntryChannel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JournalEntryChannel",
                table: "JournalEntryChannel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntry_JournalEntryChannel_JournalEntryChannelId",
                table: "JournalEntry",
                column: "JournalEntryChannelId",
                principalTable: "JournalEntryChannel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
