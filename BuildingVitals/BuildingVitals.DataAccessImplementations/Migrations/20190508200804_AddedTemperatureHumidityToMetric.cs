using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingVitals.DataAccessImplementations.Migrations
{
    public partial class AddedTemperatureHumidityToMetric : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                schema: "BuildingVitals",
                table: "Metric");

            migrationBuilder.AddColumn<string>(
                name: "Humidty",
                schema: "BuildingVitals",
                table: "Metric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Temperature",
                schema: "BuildingVitals",
                table: "Metric",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Humidty",
                schema: "BuildingVitals",
                table: "Metric");

            migrationBuilder.DropColumn(
                name: "Temperature",
                schema: "BuildingVitals",
                table: "Metric");

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                schema: "BuildingVitals",
                table: "Metric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
