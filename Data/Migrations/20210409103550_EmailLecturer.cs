using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentConsulting.Data.Migrations
{
    public partial class EmailLecturer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Lecturers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Lecturers");
        }
    }
}
