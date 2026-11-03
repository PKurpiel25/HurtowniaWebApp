using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HurtowniaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Update7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tytuł",
                table: "Zapytania",
                type: "nvarchar(45)",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tytuł",
                table: "Zapytania",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(45)",
                oldMaxLength: 45);
        }
    }
}
