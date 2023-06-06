using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class renametableTagstoNoteTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Notes_NoteId",
                table: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "NoteTags");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_NoteId",
                table: "NoteTags",
                newName: "IX_NoteTags_NoteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoteTags",
                table: "NoteTags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteTags_Notes_NoteId",
                table: "NoteTags",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteTags_Notes_NoteId",
                table: "NoteTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NoteTags",
                table: "NoteTags");

            migrationBuilder.RenameTable(
                name: "NoteTags",
                newName: "Tags");

            migrationBuilder.RenameIndex(
                name: "IX_NoteTags_NoteId",
                table: "Tags",
                newName: "IX_Tags_NoteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Notes_NoteId",
                table: "Tags",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
