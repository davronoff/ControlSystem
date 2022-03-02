using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectDavomat.Data.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_courseCategories_CourseCategoryId",
                table: "courses");

            migrationBuilder.DropForeignKey(
                name: "FK_teachers_courses_CourseId",
                table: "teachers");

            migrationBuilder.DropIndex(
                name: "IX_teachers_CourseId",
                table: "teachers");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "teachers");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseCategoryId",
                table: "courses",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_courses_courseCategories_CourseCategoryId",
                table: "courses",
                column: "CourseCategoryId",
                principalTable: "courseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_courses_courseCategories_CourseCategoryId",
                table: "courses");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "teachers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseCategoryId",
                table: "courses",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_teachers_CourseId",
                table: "teachers",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_courses_courseCategories_CourseCategoryId",
                table: "courses",
                column: "CourseCategoryId",
                principalTable: "courseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_teachers_courses_CourseId",
                table: "teachers",
                column: "CourseId",
                principalTable: "courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
