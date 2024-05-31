using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemnantsProject.Data.Migrations
{
    public partial class SlabsAddedPriceAndState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Slabs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Slabs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Slabs");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Slabs");
        }
    }
}
