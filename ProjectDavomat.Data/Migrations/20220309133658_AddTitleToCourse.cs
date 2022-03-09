using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDavomat.Data.Migrations
{
    public partial class AddTitleToCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "courses",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "courses");
        }
    }
}
