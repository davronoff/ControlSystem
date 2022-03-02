using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDavomat.Data.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telefonraqam",
                table: "students",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "MyService",
                table: "services",
                newName: "LifeTimeService");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "services",
                type: "text",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "students",
                newName: "Telefonraqam");

            migrationBuilder.RenameColumn(
                name: "LifeTimeService",
                table: "services",
                newName: "MyService");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "services",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
