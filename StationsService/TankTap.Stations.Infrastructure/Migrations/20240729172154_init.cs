using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TankTap.Stations.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TankTap");

            migrationBuilder.CreateTable(
                name: "PointOfSaleTypes",
                schema: "TankTap",
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
                name: "Regions",
                schema: "TankTap",
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
                schema: "TankTap",
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
                        principalSchema: "TankTap",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                schema: "TankTap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_CityId = table.Column<int>(type: "int", nullable: false),
                    Address_District = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ERPCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stations_Cities_Address_CityId",
                        column: x => x.Address_CityId,
                        principalSchema: "TankTap",
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "TankTap",
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
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Stations_StationId",
                        column: x => x.StationId,
                        principalSchema: "TankTap",
                        principalTable: "Stations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StationPointOfSales",
                schema: "TankTap",
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
                        principalSchema: "TankTap",
                        principalTable: "PointOfSaleTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StationPointOfSales_Stations_StationId",
                        column: x => x.StationId,
                        principalSchema: "TankTap",
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StationProducts",
                schema: "TankTap",
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
                        principalSchema: "TankTap",
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StationProducts_Stations_StationId",
                        column: x => x.StationId,
                        principalSchema: "TankTap",
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tanks",
                schema: "TankTap",
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
                        principalSchema: "TankTap",
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tanks_Stations_StationId",
                        column: x => x.StationId,
                        principalSchema: "TankTap",
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pumps",
                schema: "TankTap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TankId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ERPCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pumps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pumps_Stations_StationId",
                        column: x => x.StationId,
                        principalSchema: "TankTap",
                        principalTable: "Stations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pumps_Tanks_TankId",
                        column: x => x.TankId,
                        principalSchema: "TankTap",
                        principalTable: "Tanks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_RegionId",
                schema: "TankTap",
                table: "Cities",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StationId",
                schema: "TankTap",
                table: "Products",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pumps_StationId",
                schema: "TankTap",
                table: "Pumps",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Pumps_TankId",
                schema: "TankTap",
                table: "Pumps",
                column: "TankId");

            migrationBuilder.CreateIndex(
                name: "IX_StationPointOfSales_PointOfSaleTypeId",
                schema: "TankTap",
                table: "StationPointOfSales",
                column: "PointOfSaleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StationProducts_ProductId",
                schema: "TankTap",
                table: "StationProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StationProducts_StationId",
                schema: "TankTap",
                table: "StationProducts",
                column: "StationId");

            migrationBuilder.CreateIndex(
                name: "IX_Stations_Address_CityId",
                schema: "TankTap",
                table: "Stations",
                column: "Address_CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_ProductId",
                schema: "TankTap",
                table: "Tanks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Tanks_StationId",
                schema: "TankTap",
                table: "Tanks",
                column: "StationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pumps",
                schema: "TankTap");

            migrationBuilder.DropTable(
                name: "StationPointOfSales",
                schema: "TankTap");

            migrationBuilder.DropTable(
                name: "StationProducts",
                schema: "TankTap");

            migrationBuilder.DropTable(
                name: "Tanks",
                schema: "TankTap");

            migrationBuilder.DropTable(
                name: "PointOfSaleTypes",
                schema: "TankTap");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "TankTap");

            migrationBuilder.DropTable(
                name: "Stations",
                schema: "TankTap");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "TankTap");

            migrationBuilder.DropTable(
                name: "Regions",
                schema: "TankTap");
        }
    }
}
