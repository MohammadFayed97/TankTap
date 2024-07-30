using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TankTap.Stations.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stations_StationId",
                schema: "TankTap",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Pumps_Stations_StationId",
                schema: "TankTap",
                table: "Pumps");

            migrationBuilder.DropForeignKey(
                name: "FK_Stations_Cities_Address_CityId",
                schema: "TankTap",
                table: "Stations");

            migrationBuilder.DropIndex(
                name: "IX_Pumps_StationId",
                schema: "TankTap",
                table: "Pumps");

            migrationBuilder.DropIndex(
                name: "IX_Products_StationId",
                schema: "TankTap",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StationId",
                schema: "TankTap",
                table: "Pumps");

            migrationBuilder.DropColumn(
                name: "StationId",
                schema: "TankTap",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Address_District",
                schema: "TankTap",
                table: "Stations",
                newName: "District");

            migrationBuilder.AddForeignKey(
                name: "Stations_Cities_CityId",
                schema: "TankTap",
                table: "Stations",
                column: "Address_CityId",
                principalSchema: "TankTap",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Stations_Cities_CityId",
                schema: "TankTap",
                table: "Stations");

            migrationBuilder.RenameColumn(
                name: "District",
                schema: "TankTap",
                table: "Stations",
                newName: "Address_District");

            migrationBuilder.AddColumn<int>(
                name: "StationId",
                schema: "TankTap",
                table: "Pumps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StationId",
                schema: "TankTap",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pumps_StationId",
                schema: "TankTap",
                table: "Pumps",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StationId",
                schema: "TankTap",
                table: "Products",
                column: "StationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stations_StationId",
                schema: "TankTap",
                table: "Products",
                column: "StationId",
                principalSchema: "TankTap",
                principalTable: "Stations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pumps_Stations_StationId",
                schema: "TankTap",
                table: "Pumps",
                column: "StationId",
                principalSchema: "TankTap",
                principalTable: "Stations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_Cities_Address_CityId",
                schema: "TankTap",
                table: "Stations",
                column: "Address_CityId",
                principalSchema: "TankTap",
                principalTable: "Cities",
                principalColumn: "Id");
        }
    }
}
