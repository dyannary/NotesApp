using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notes.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addColorfieldtoNoteentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Notes");
        }
    }
}
