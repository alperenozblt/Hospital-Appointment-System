using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemiii.Migrations
{
    public partial class deneme1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Randevular",
                table: "Randevular");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Poliklinik",
                table: "Poliklinik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hastaneler",
                table: "Hastaneler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doktorlar",
                table: "Doktorlar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalismaGunleris",
                table: "CalismaGunleris");

            migrationBuilder.RenameTable(
                name: "Randevular",
                newName: "Randevus");

            migrationBuilder.RenameTable(
                name: "Poliklinik",
                newName: "Polikliniks");

            migrationBuilder.RenameTable(
                name: "Hastaneler",
                newName: "Hastanes");

            migrationBuilder.RenameTable(
                name: "Doktorlar",
                newName: "Doktors");

            migrationBuilder.RenameTable(
                name: "CalismaGunleris",
                newName: "CalismaGunlerii");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Randevus",
                table: "Randevus",
                column: "RandevuID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Polikliniks",
                table: "Polikliniks",
                column: "PoliklinikId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hastanes",
                table: "Hastanes",
                column: "HastaneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doktors",
                table: "Doktors",
                column: "DoktorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalismaGunlerii",
                table: "CalismaGunlerii",
                column: "CalismaGünüId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Randevus",
                table: "Randevus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Polikliniks",
                table: "Polikliniks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hastanes",
                table: "Hastanes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Doktors",
                table: "Doktors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CalismaGunlerii",
                table: "CalismaGunlerii");

            migrationBuilder.RenameTable(
                name: "Randevus",
                newName: "Randevular");

            migrationBuilder.RenameTable(
                name: "Polikliniks",
                newName: "Poliklinik");

            migrationBuilder.RenameTable(
                name: "Hastanes",
                newName: "Hastaneler");

            migrationBuilder.RenameTable(
                name: "Doktors",
                newName: "Doktorlar");

            migrationBuilder.RenameTable(
                name: "CalismaGunlerii",
                newName: "CalismaGunleris");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Randevular",
                table: "Randevular",
                column: "RandevuID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Poliklinik",
                table: "Poliklinik",
                column: "PoliklinikId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hastaneler",
                table: "Hastaneler",
                column: "HastaneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Doktorlar",
                table: "Doktorlar",
                column: "DoktorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CalismaGunleris",
                table: "CalismaGunleris",
                column: "CalismaGünüId");
        }
    }
}
