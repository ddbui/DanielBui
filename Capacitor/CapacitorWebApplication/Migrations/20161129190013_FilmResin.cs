using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CapacitorWebApplication.Migrations
{
    public partial class FilmResin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmResin",
                columns: table => new
                {
                    FilmId = table.Column<int>(nullable: false),
                    ResinId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmResin", x => new { x.FilmId, x.ResinId });
                    table.ForeignKey(
                        name: "FK_FilmResin_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmResin_Resins_ResinId",
                        column: x => x.ResinId,
                        principalTable: "Resins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmResin_ResinId",
                table: "FilmResin",
                column: "ResinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmResin");
        }
    }
}
