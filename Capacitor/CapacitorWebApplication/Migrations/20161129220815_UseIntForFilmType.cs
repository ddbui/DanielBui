using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CapacitorWebApplication.Migrations
{
    public partial class UseIntForFilmType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_FilmTypes_FilmTypeId",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Films_FilmTypeId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "FilmTypeId",
                table: "Films");

            migrationBuilder.AddColumn<int>(
                name: "FilmType",
                table: "Films",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilmType",
                table: "Films");

            migrationBuilder.AddColumn<int>(
                name: "FilmTypeId",
                table: "Films",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Films_FilmTypeId",
                table: "Films",
                column: "FilmTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_FilmTypes_FilmTypeId",
                table: "Films",
                column: "FilmTypeId",
                principalTable: "FilmTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
