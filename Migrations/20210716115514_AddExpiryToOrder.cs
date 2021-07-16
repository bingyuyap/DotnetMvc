using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotnetMvc.Migrations
{
    public partial class AddExpiryToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiryDateTime",
                table: "Order",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiryDateTime",
                table: "Order");
        }
    }
}
