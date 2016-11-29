using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CapacitorWebApplication.Migrations
{
    public partial class TakeOutFilmType : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
