using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rmzmeterproject.Migrations
{
    /// <inheritdoc />
    public partial class meterDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    cityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cityname = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.cityId);
                });

            migrationBuilder.CreateTable(
                name: "facilities",
                columns: table => new
                {
                    FacilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacilityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_facilities", x => x.FacilityId);
                    table.ForeignKey(
                        name: "FK_facilities_cities_cityId",
                        column: x => x.cityId,
                        principalTable: "cities",
                        principalColumn: "cityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "buildings",
                columns: table => new
                {
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buildings", x => x.BuildingId);
                    table.ForeignKey(
                        name: "FK_buildings_facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "floors",
                columns: table => new
                {
                    FloorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuildingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_floors", x => x.FloorId);
                    table.ForeignKey(
                        name: "FK_floors_buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "zones",
                columns: table => new
                {
                    ZoneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZoneName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeofmeterPresent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FloorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zones", x => x.ZoneId);
                    table.ForeignKey(
                        name: "FK_zones_floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "floors",
                        principalColumn: "FloorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "meters",
                columns: table => new
                {
                    meterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    meterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    meterType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    installationTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    currentTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    meterreading = table.Column<long>(type: "bigint", nullable: false),
                    ZoneId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meters", x => x.meterId);
                    table.ForeignKey(
                        name: "FK_meters_zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "zones",
                        principalColumn: "ZoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_buildings_FacilityId",
                table: "buildings",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_facilities_cityId",
                table: "facilities",
                column: "cityId");

            migrationBuilder.CreateIndex(
                name: "IX_floors_BuildingId",
                table: "floors",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_meters_ZoneId",
                table: "meters",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_zones_FloorId",
                table: "zones",
                column: "FloorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "meters");

            migrationBuilder.DropTable(
                name: "zones");

            migrationBuilder.DropTable(
                name: "floors");

            migrationBuilder.DropTable(
                name: "buildings");

            migrationBuilder.DropTable(
                name: "facilities");

            migrationBuilder.DropTable(
                name: "cities");
        }
    }
}
