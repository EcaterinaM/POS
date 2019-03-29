using Microsoft.EntityFrameworkCore.Migrations;

namespace BuildingVitals.DataAccessImplementations.Migrations
{
    public partial class AddedSurnameToUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Surname",
                schema: "BuildingVitals",
                table: "User",
                unicode: false,
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                schema: "BuildingVitals",
                table: "User");
        }
    }
}
