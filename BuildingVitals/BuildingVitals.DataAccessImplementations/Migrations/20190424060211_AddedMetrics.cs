using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingVitals.DataAccessImplementations.Migrations
{
    public partial class AddedMetrics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                schema: "BuildingVitals",
                table: "Sensor");

            migrationBuilder.DropColumn(
                name: "Value",
                schema: "BuildingVitals",
                table: "Sensor");

            migrationBuilder.CreateTable(
                name: "Metric",
                schema: "BuildingVitals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SensorId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Metric", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Metric_Sensor_SensorId",
                        column: x => x.SensorId,
                        principalSchema: "BuildingVitals",
                        principalTable: "Sensor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Metric_SensorId",
                schema: "BuildingVitals",
                table: "Metric",
                column: "SensorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Metric",
                schema: "BuildingVitals");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                schema: "BuildingVitals",
                table: "Sensor",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                schema: "BuildingVitals",
                table: "Sensor",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
