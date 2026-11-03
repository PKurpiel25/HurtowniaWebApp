using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HurtowniaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Update8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Usunięty",
                table: "Produkty",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usunięty",
                table: "Produkty");
        }
    }
}
