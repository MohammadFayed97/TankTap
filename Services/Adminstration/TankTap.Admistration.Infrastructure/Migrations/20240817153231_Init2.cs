using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TankTap.Admistration.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "adminstration");

            migrationBuilder.RenameTable(
                name: "Tanks",
                schema: "stations",
                newName: "Tanks",
                newSchema: "adminstration");

            migrationBuilder.RenameTable(
                name: "Stations",
                schema: "stations",
                newName: "Stations",
                newSchema: "adminstration");

            migrationBuilder.RenameTable(
                name: "StationProducts",
                schema: "stations",
                newName: "StationProducts",
                newSchema: "adminstration");

            migrationBuilder.RenameTable(
                name: "StationPointOfSales",
                schema: "stations",
                newName: "StationPointOfSales",
                newSchema: "adminstration");

            migrationBuilder.RenameTable(
                name: "Regions",
                schema: "stations",
                newName: "Regions",
                newSchema: "adminstration");

            migrationBuilder.RenameTable(
                name: "Pumps",
                schema: "stations",
                newName: "Pumps",
                newSchema: "adminstration");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "stations",
                newName: "Products",
                newSchema: "adminstration");

            migrationBuilder.RenameTable(
                name: "PointOfSaleTypes",
                schema: "stations",
                newName: "PointOfSaleTypes",
                newSchema: "adminstration");

            migrationBuilder.RenameTable(
                name: "Cities",
                schema: "stations",
                newName: "Cities",
                newSchema: "adminstration");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "stations");

            migrationBuilder.RenameTable(
                name: "Tanks",
                schema: "adminstration",
                newName: "Tanks",
                newSchema: "stations");

            migrationBuilder.RenameTable(
                name: "Stations",
                schema: "adminstration",
                newName: "Stations",
                newSchema: "stations");

            migrationBuilder.RenameTable(
                name: "StationProducts",
                schema: "adminstration",
                newName: "StationProducts",
                newSchema: "stations");

            migrationBuilder.RenameTable(
                name: "StationPointOfSales",
                schema: "adminstration",
                newName: "StationPointOfSales",
                newSchema: "stations");

            migrationBuilder.RenameTable(
                name: "Regions",
                schema: "adminstration",
                newName: "Regions",
                newSchema: "stations");

            migrationBuilder.RenameTable(
                name: "Pumps",
                schema: "adminstration",
                newName: "Pumps",
                newSchema: "stations");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "adminstration",
                newName: "Products",
                newSchema: "stations");

            migrationBuilder.RenameTable(
                name: "PointOfSaleTypes",
                schema: "adminstration",
                newName: "PointOfSaleTypes",
                newSchema: "stations");

            migrationBuilder.RenameTable(
                name: "Cities",
                schema: "adminstration",
                newName: "Cities",
                newSchema: "stations");
        }
    }
}
