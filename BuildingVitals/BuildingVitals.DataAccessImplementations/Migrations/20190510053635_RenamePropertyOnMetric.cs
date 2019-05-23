using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingVitals.DataAccessImplementations.Migrations
{
    public partial class RenamePropertyOnMetric : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Humidty",
                schema: "BuildingVitals",
                table: "Metric",
                newName: "Humidity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Humidity",
                schema: "BuildingVitals",
                table: "Metric",
                newName: "Humidty");
        }
    }
}
