using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HurtowniaAPI.Migrations
{
    /// <inheritdoc />
    public partial class Update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshTime",
                table: "AspNetUsers",
                type: "smalldatetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<string>(
                name: "PESEL",
                table: "AspNetUsers",
                type: "char(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(11)",
                oldMaxLength: 11);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RefreshTime",
                table: "AspNetUsers",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PESEL",
                table: "AspNetUsers",
                type: "char(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "char(11)",
                oldMaxLength: 11,
                oldNullable: true);
        }
    }
}
