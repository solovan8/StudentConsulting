using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentConsulting.Data.Migrations
{
    public partial class Meeh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Lecturers");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Lecturers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Lecturers");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Lecturers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
