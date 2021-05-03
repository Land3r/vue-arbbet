using Microsoft.EntityFrameworkCore.Migrations;

namespace Arbbet.Connectors.Dal.Migrations
{
    public partial class AddCountryFlagName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FlagName",
                schema: "Domain",
                table: "Countries",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlagName",
                schema: "Domain",
                table: "Countries");
        }
    }
}
