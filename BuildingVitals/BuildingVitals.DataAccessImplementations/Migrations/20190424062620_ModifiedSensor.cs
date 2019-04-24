using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingVitals.DataAccessImplementations.Migrations
{
    public partial class ModifiedSensor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentSensor",
                schema: "BuildingVitals");

            migrationBuilder.AddColumn<Guid>(
                name: "ApartmentId",
                schema: "BuildingVitals",
                table: "Sensor",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_ApartmentId",
                schema: "BuildingVitals",
                table: "Sensor",
                column: "ApartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_Apartment_ApartmentId",
                schema: "BuildingVitals",
                table: "Sensor",
                column: "ApartmentId",
                principalSchema: "BuildingVitals",
                principalTable: "Apartment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_Apartment_ApartmentId",
                schema: "BuildingVitals",
                table: "Sensor");

            migrationBuilder.DropIndex(
                name: "IX_Sensor_ApartmentId",
                schema: "BuildingVitals",
                table: "Sensor");

            migrationBuilder.DropColumn(
                name: "ApartmentId",
                schema: "BuildingVitals",
                table: "Sensor");

            migrationBuilder.CreateTable(
                name: "ApartmentSensor",
                schema: "BuildingVitals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ApartmentId = table.Column<Guid>(nullable: false),
                    SensorId = table.Column<Guid>(nullable: false)
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
                name: "IX_ApartmentSensor_ApartmentId",
                schema: "BuildingVitals",
                table: "ApartmentSensor",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentSensor_SensorId",
                schema: "BuildingVitals",
                table: "ApartmentSensor",
                column: "SensorId");
        }
    }
}
