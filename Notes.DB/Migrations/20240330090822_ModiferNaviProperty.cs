using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModiferNaviProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Notes_PersonId",
                schema: "rec",
                table: "Notes");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_PersonId",
                schema: "rec",
                table: "Notes",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Notes_PersonId",
                schema: "rec",
                table: "Notes");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_PersonId",
                schema: "rec",
                table: "Notes",
                column: "PersonId",
                unique: true);
        }
    }
}
