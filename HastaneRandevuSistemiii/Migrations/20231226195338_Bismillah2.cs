using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemiii.Migrations
{
    public partial class Bismillah2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HastaneAddress",
                table: "Hastanes",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HastaneTel",
                table: "Hastanes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HastaneAddress",
                table: "Hastanes");

            migrationBuilder.DropColumn(
                name: "HastaneTel",
                table: "Hastanes");
        }
    }
}
