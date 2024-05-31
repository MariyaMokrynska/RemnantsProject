using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemnantsProject.Data.Migrations
{
    public partial class UpdatedSlabFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlabPickedUp",
                table: "Slabs");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Slabs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SlabPickedUp",
                table: "Slabs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Slabs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
