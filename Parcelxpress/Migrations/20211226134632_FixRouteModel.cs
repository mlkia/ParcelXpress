using Microsoft.EntityFrameworkCore.Migrations;

namespace Parcelxpress.Migrations
{
    public partial class FixRouteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cage",
                table: "Route");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cage",
                table: "Route",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
