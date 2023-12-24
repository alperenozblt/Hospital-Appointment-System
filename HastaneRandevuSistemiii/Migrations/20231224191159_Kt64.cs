using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemiii.Migrations
{
    public partial class Kt64 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RandevuID",
                table: "Randevus",
                newName: "RandevuId");

            migrationBuilder.AlterColumn<string>(
                name: "Günler",
                table: "CalismaGunlerii",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.CreateIndex(
                name: "IX_Randevus_DoktorId",
                table: "Randevus",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_CalismaGunlerii_DoktorId",
                table: "CalismaGunlerii",
                column: "DoktorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalismaGunlerii_Doktors_DoktorId",
                table: "CalismaGunlerii",
                column: "DoktorId",
                principalTable: "Doktors",
                principalColumn: "DoktorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevus_Doktors_DoktorId",
                table: "Randevus",
                column: "DoktorId",
                principalTable: "Doktors",
                principalColumn: "DoktorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalismaGunlerii_Doktors_DoktorId",
                table: "CalismaGunlerii");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevus_Doktors_DoktorId",
                table: "Randevus");

            migrationBuilder.DropIndex(
                name: "IX_Randevus_DoktorId",
                table: "Randevus");

            migrationBuilder.DropIndex(
                name: "IX_CalismaGunlerii_DoktorId",
                table: "CalismaGunlerii");

            migrationBuilder.RenameColumn(
                name: "RandevuId",
                table: "Randevus",
                newName: "RandevuID");

            migrationBuilder.AlterColumn<string>(
                name: "Günler",
                table: "CalismaGunlerii",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
