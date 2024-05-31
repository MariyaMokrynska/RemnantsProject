using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemnantsProject.Data.Migrations
{
    public partial class AddedSlabFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfPayment",
                table: "Slabs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeIdDeliveringSlab",
                table: "Slabs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeIdReceivedPayment",
                table: "Slabs",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfPayment",
                table: "Slabs");

            migrationBuilder.DropColumn(
                name: "EmployeeIdDeliveringSlab",
                table: "Slabs");

            migrationBuilder.DropColumn(
                name: "EmployeeIdReceivedPayment",
                table: "Slabs");
        }
    }
}
