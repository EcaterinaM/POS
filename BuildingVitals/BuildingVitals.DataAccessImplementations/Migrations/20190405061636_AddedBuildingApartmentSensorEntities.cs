using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingVitals.DataAccessImplementations.Migrations
{
    public partial class AddedBuildingApartmentSensorEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Building",
                schema: "BuildingVitals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Building", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Building_User_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "BuildingVitals",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sensor",
                schema: "BuildingVitals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Apartment",
                schema: "BuildingVitals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Floor = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: false),
                    BuildingId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartment_Building_BuildingId",
                        column: x => x.BuildingId,
                        principalSchema: "BuildingVitals",
                        principalTable: "Building",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apartment_User_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "BuildingVitals",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentSensor",
                schema: "BuildingVitals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SensorId = table.Column<Guid>(nullable: false),
                    ApartmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentSensor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentSensor_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalSchema: "BuildingVitals",
                        principalTable: "Apartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApartmentSensor_Sensor_SensorId",
                        column: x => x.SensorId,
                        principalSchema: "BuildingVitals",
                        principalTable: "Sensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_BuildingId",
                schema: "BuildingVitals",
                table: "Apartment",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_OwnerId",
                schema: "BuildingVitals",
                table: "Apartment",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentSensor_ApartmentId",
                schema: "BuildingVitals",
                table: "ApartmentSensor",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentSensor_SensorId",
                schema: "BuildingVitals",
                table: "ApartmentSensor",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Building_OwnerId",
                schema: "BuildingVitals",
                table: "Building",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentSensor",
                schema: "BuildingVitals");

            migrationBuilder.DropTable(
                name: "Apartment",
                schema: "BuildingVitals");

            migrationBuilder.DropTable(
                name: "Sensor",
                schema: "BuildingVitals");

            migrationBuilder.DropTable(
                name: "Building",
                schema: "BuildingVitals");
        }
    }
}
