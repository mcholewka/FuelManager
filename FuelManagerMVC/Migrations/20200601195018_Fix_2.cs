using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FuelManagerMVC.Migrations
{
    public partial class Fix_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RefuelDate",
                table: "Refuels",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefuelDate",
                table: "Refuels");
        }
    }
}
