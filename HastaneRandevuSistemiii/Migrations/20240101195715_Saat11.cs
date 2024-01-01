using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HastaneRandevuSistemiii.Migrations
{
    public partial class Saat11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HastaneId",
                table: "Randevus");

            migrationBuilder.DropColumn(
                name: "PoliklinikId",
                table: "Randevus");

            migrationBuilder.RenameColumn(
                name: "RandevuTarih",
                table: "Randevus",
                newName: "RandevuGun");

            migrationBuilder.AddColumn<bool>(
                name: "IsEmpty",
                table: "Randevus",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "RandevuSaat",
                table: "Randevus",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEmpty",
                table: "Randevus");

            migrationBuilder.DropColumn(
                name: "RandevuSaat",
                table: "Randevus");

            migrationBuilder.RenameColumn(
                name: "RandevuGun",
                table: "Randevus",
                newName: "RandevuTarih");

            migrationBuilder.AddColumn<int>(
                name: "HastaneId",
                table: "Randevus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PoliklinikId",
                table: "Randevus",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
