using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Baharan.Migrations
{
    /// <inheritdoc />
    public partial class editnactionalcart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NatopnalCodeImageUrl",
                table: "Documents",
                newName: "NationalCartImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NationalCartImageUrl",
                table: "Documents",
                newName: "NatopnalCodeImageUrl");
        }
    }
}
