using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CapacitorWebApplication.Migrations
{
    public partial class StartOver : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Films_FilmId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Resins_Films_FilmId",
                table: "Resins");

            migrationBuilder.DropIndex(
                name: "IX_Resins_FilmId",
                table: "Resins");

            migrationBuilder.DropIndex(
                name: "IX_Materials_FilmId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "Resins");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "Materials");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "Resins",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "Materials",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resins_FilmId",
                table: "Resins",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_FilmId",
                table: "Materials",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Films_FilmId",
                table: "Materials",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resins_Films_FilmId",
                table: "Resins",
                column: "FilmId",
                principalTable: "Films",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
