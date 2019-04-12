using Microsoft.EntityFrameworkCore.Migrations;

namespace Blinkblink.Migrations
{
    public partial class aaaa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeIdol",
                table: "Images");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeIdol",
                table: "Images",
                nullable: true);
        }
    }
}
