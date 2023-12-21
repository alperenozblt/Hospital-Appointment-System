using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemiii.Migrations
{
    public partial class denemebilmemkaç : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAd",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserSoyad",
                table: "AspNetUsers",
                newName: "KullaniciSoyad");

            migrationBuilder.AddColumn<string>(
                name: "KullaniciAd",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KullaniciAd",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "KullaniciSoyad",
                table: "AspNetUsers",
                newName: "UserSoyad");

            migrationBuilder.AddColumn<string>(
                name: "UserAd",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
