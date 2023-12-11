using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Round1.Migrations
{
    /// <inheritdoc />
    public partial class ModelDone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doktors_Polikliniks_PoliklinikId",
                table: "Doktors");

            migrationBuilder.DropIndex(
                name: "IX_Doktors_PoliklinikId",
                table: "Doktors");

            migrationBuilder.DropColumn(
                name: "Brans",
                table: "Doktors");

            migrationBuilder.AlterColumn<string>(
                name: "HastaId",
                table: "Randevus",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "HastaId1",
                table: "Randevus",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "TCKimlikNumarası",
                table: "Hastas",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DogumYılı",
                table: "Hastas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HastaPassword",
                table: "Hastas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "HastaneId",
                table: "AnaBilimDalis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "DoktorIzinGunus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaslangıcTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BitisTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaslangıcSaat = table.Column<TimeSpan>(type: "time", nullable: false),
                    BitisSaat = table.Column<TimeSpan>(type: "time", nullable: false),
                    DoktorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoktorIzinGunus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoktorIzinGunus_Doktors_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Randevus_DoktorId",
                table: "Randevus",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevus_HastaId1",
                table: "Randevus",
                column: "HastaId1");

            migrationBuilder.CreateIndex(
                name: "IX_DoktorIzinGunus_DoktorId",
                table: "DoktorIzinGunus",
                column: "DoktorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Randevus_Doktors_DoktorId",
                table: "Randevus",
                column: "DoktorId",
                principalTable: "Doktors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Randevus_Hastas_HastaId1",
                table: "Randevus",
                column: "HastaId1",
                principalTable: "Hastas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Randevus_Doktors_DoktorId",
                table: "Randevus");

            migrationBuilder.DropForeignKey(
                name: "FK_Randevus_Hastas_HastaId1",
                table: "Randevus");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "DoktorIzinGunus");

            migrationBuilder.DropIndex(
                name: "IX_Randevus_DoktorId",
                table: "Randevus");

            migrationBuilder.DropIndex(
                name: "IX_Randevus_HastaId1",
                table: "Randevus");

            migrationBuilder.DropColumn(
                name: "HastaId1",
                table: "Randevus");

            migrationBuilder.DropColumn(
                name: "DogumYılı",
                table: "Hastas");

            migrationBuilder.DropColumn(
                name: "HastaPassword",
                table: "Hastas");

            migrationBuilder.DropColumn(
                name: "HastaneId",
                table: "AnaBilimDalis");

            migrationBuilder.AlterColumn<int>(
                name: "HastaId",
                table: "Randevus",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TCKimlikNumarası",
                table: "Hastas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Brans",
                table: "Doktors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Doktors_PoliklinikId",
                table: "Doktors",
                column: "PoliklinikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doktors_Polikliniks_PoliklinikId",
                table: "Doktors",
                column: "PoliklinikId",
                principalTable: "Polikliniks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
