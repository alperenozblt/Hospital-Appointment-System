using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemiii.Migrations
{
    public partial class Kt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "KullaniciId1",
                table: "Randevus",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Doktors",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Randevus_KullaniciId1",
                table: "Randevus",
                column: "KullaniciId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevus_AspNetUsers_KullaniciId1",
                table: "Randevus",
                column: "KullaniciId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevus_AspNetUsers_KullaniciId1",
                table: "Randevus");

            migrationBuilder.DropIndex(
                name: "IX_Randevus_KullaniciId1",
                table: "Randevus");

            migrationBuilder.DropColumn(
                name: "KullaniciId1",
                table: "Randevus");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Doktors",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
