using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TankTap.Admistration.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "adminstration");

            migrationBuilder.CreateTable(
                name: "PointOfSaleTypes",
                schema: "adminstration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BnName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointOfSaleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "adminstration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ERPCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                schema: "adminstration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BnName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "adminstration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BnName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "adminstration",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                schema: "adminstration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_CityId = table.Column<int>(type: "int", nullable: false),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ERPCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                    table.ForeignKey(
                        name: "Stations_Cities_CityId",
                        column: x => x.Address_CityId,
                        principalSchema: "adminstration",
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StationPointOfSales",
                schema: "adminstration",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AndroidId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PointOfSaleTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationPointOfSales", x => new { x.StationId, x.Id });
                    table.ForeignKey(
                        name: "FK_StationPointOfSales_PointOfSaleTypes_PointOfSaleTypeId",
                        column: x => x.PointOfSaleTypeId,
                        principalSchema: "adminstration",
                        principalTable: "PointOfSaleTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StationPointOfSales_Stations_StationId",
                        column: x => x.StationId,
                        principalSchema: "adminstration",
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StationProducts",
                schema: "adminstration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", precision: 5, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StationProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "adminstration",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StationProducts_Stations_StationId",
                        column: x => x.StationId,
                        principalSchema: "adminstration",
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tanks",
                schema: "adminstration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tanks_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "adminstration",
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tanks_Stations_StationId",
                        column: x => x.StationId,
                        principalSchema: "adminstration",
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pumps",
                schema: "adminstration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TankId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ERPCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pumps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pumps_Tanks_TankId",
                        column: x => x.TankId,
                        principalSchema: "adminstration",
                        principalTable: "Tanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_RegionId",
                schema: "adminstration",
                table: "Cities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Pumps_TankId",
                schema: "adminstration",
                table: "Pumps",
                column: "TankId");

            migrationBuilder.CreateIndex(
                name: "IX_StationPointOfSales_PointOfSaleTypeId",
                schema: "adminstration",
                table: "StationPointOfSales",
                column: "PointOfSaleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StationProducts_ProductId",
                schema: "adminstration",
                table: "StationProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StationProducts_StationId",
                schema: "adminstration",
                table: "StationProducts",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_Address_CityId",
                schema: "adminstration",
                table: "Stations",
                column: "Address_CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_ProductId",
                schema: "adminstration",
                table: "Tanks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_StationId",
                schema: "adminstration",
                table: "Tanks",
                column: "StationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pumps",
                schema: "adminstration");

            migrationBuilder.DropTable(
                name: "StationPointOfSales",
                schema: "adminstration");

            migrationBuilder.DropTable(
                name: "StationProducts",
                schema: "adminstration");

            migrationBuilder.DropTable(
                name: "Tanks",
                schema: "adminstration");

            migrationBuilder.DropTable(
                name: "PointOfSaleTypes",
                schema: "adminstration");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "adminstration");

            migrationBuilder.DropTable(
                name: "Stations",
                schema: "adminstration");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "adminstration");

            migrationBuilder.DropTable(
                name: "Regions",
                schema: "adminstration");
        }
    }
}
