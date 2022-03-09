using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDavomat.Data.Migrations
{
    public partial class AddSocialToTeachStaff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Social",
                table: "teachers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Social",
                table: "staffs",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Social",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "Social",
                table: "staffs");
        }
    }
}
