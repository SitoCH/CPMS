using Microsoft.EntityFrameworkCore.Migrations;

namespace CPMS.Common.Migrations
{
    public partial class Journals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Journal_Interventions_InterventionId",
                table: "Journal");

            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntry_Journal_JournalId",
                table: "JournalEntry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Journal",
                table: "Journal");

            migrationBuilder.RenameTable(
                name: "Journal",
                newName: "Journals");

            migrationBuilder.RenameIndex(
                name: "IX_Journal_InterventionId",
                table: "Journals",
                newName: "IX_Journals_InterventionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Journals",
                table: "Journals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntry_Journals_JournalId",
                table: "JournalEntry",
                column: "JournalId",
                principalTable: "Journals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Journals_Interventions_InterventionId",
                table: "Journals",
                column: "InterventionId",
                principalTable: "Interventions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JournalEntry_Journals_JournalId",
                table: "JournalEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_Journals_Interventions_InterventionId",
                table: "Journals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Journals",
                table: "Journals");

            migrationBuilder.RenameTable(
                name: "Journals",
                newName: "Journal");

            migrationBuilder.RenameIndex(
                name: "IX_Journals_InterventionId",
                table: "Journal",
                newName: "IX_Journal_InterventionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Journal",
                table: "Journal",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Journal_Interventions_InterventionId",
                table: "Journal",
                column: "InterventionId",
                principalTable: "Interventions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JournalEntry_Journal_JournalId",
                table: "JournalEntry",
                column: "JournalId",
                principalTable: "Journal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
