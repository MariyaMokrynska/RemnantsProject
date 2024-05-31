using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemnantsProject.Data.Migrations
{
    public partial class addedSurfaceTypesAndSlabs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SurfaceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurfaceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slabs",
                columns: table => new
                {
                    SlabId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurfaceTypeId = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Thickness = table.Column<int>(type: "int", nullable: false),
                    HoldDueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoldCustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoldCustomerId = table.Column<int>(type: "int", nullable: true),
                    PayConfirmationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SlabPickedUp = table.Column<bool>(type: "bit", nullable: false),
                    SlabPickedUpDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slabs", x => x.SlabId);
                    table.ForeignKey(
                        name: "FK_Slabs_Colours_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slabs_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Slabs_SurfaceTypes_SurfaceTypeId",
                        column: x => x.SurfaceTypeId,
                        principalTable: "SurfaceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Slabs_ColorId",
                table: "Slabs",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Slabs_ManufacturerId",
                table: "Slabs",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Slabs_SurfaceTypeId",
                table: "Slabs",
                column: "SurfaceTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Slabs");

            migrationBuilder.DropTable(
                name: "SurfaceTypes");
        }
    }
}
