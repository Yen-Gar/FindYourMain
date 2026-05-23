using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindYourMain.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCharacterModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "Characters",
                newName: "Game");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Game",
                table: "Characters",
                newName: "GameID");
        }
    }
}
