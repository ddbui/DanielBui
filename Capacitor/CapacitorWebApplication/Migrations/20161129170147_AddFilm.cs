using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CapacitorWebApplication.Migrations
{
    public partial class AddFilm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResinId",
                table: "Resins",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                table: "Materials",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "FilmTypeId",
                table: "FilmTypes",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "Resins",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "Materials",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FilmThickness = table.Column<double>(nullable: false),
                    FilmTypeId = table.Column<int>(nullable: true),
                    HoldTime = table.Column<double>(nullable: false),
                    StampCapSerialNumber = table.Column<string>(nullable: true),
                    StepsToZeroCap = table.Column<int>(nullable: false),
                    VatZeroCap = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_FilmTypes_FilmTypeId",
                        column: x => x.FilmTypeId,
                        principalTable: "FilmTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resins_FilmId",
                table: "Resins",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_FilmId",
                table: "Materials",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Films_FilmTypeId",
                table: "Films",
                column: "FilmTypeId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Films_FilmId",
                table: "Materials");

            migrationBuilder.DropForeignKey(
                name: "FK_Resins_Films_FilmId",
                table: "Resins");

            migrationBuilder.DropTable(
                name: "Films");

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

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Resins",
                newName: "ResinId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Materials",
                newName: "MaterialId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "FilmTypes",
                newName: "FilmTypeId");
        }
    }
}
