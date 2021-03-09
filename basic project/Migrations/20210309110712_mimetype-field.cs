using Microsoft.EntityFrameworkCore.Migrations;

namespace basic_project.Migrations
{
    public partial class mimetypefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "size",
                table: "Files",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "size",
                table: "Files");
        }
    }
}
