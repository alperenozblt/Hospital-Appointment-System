using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemiii.Migrations
{
    public partial class Kt3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Doktors",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateIndex(
                name: "IX_Polikliniks_HastaneId",
                table: "Polikliniks",
                column: "HastaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Doktors_PoliklinikId",
                table: "Doktors",
                column: "PoliklinikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doktors_Polikliniks_PoliklinikId",
                table: "Doktors",
                column: "PoliklinikId",
                principalTable: "Polikliniks",
                principalColumn: "PoliklinikId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Polikliniks_Hastanes_HastaneId",
                table: "Polikliniks",
                column: "HastaneId",
                principalTable: "Hastanes",
                principalColumn: "HastaneId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doktors_Polikliniks_PoliklinikId",
                table: "Doktors");

            migrationBuilder.DropForeignKey(
                name: "FK_Polikliniks_Hastanes_HastaneId",
                table: "Polikliniks");

            migrationBuilder.DropIndex(
                name: "IX_Polikliniks_HastaneId",
                table: "Polikliniks");

            migrationBuilder.DropIndex(
                name: "IX_Doktors_PoliklinikId",
                table: "Doktors");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Doktors",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
