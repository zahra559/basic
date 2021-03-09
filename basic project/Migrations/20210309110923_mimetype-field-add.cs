using Microsoft.EntityFrameworkCore.Migrations;

namespace basic_project.Migrations
{
    public partial class mimetypefieldadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "mimeType",
                table: "Files",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mimeType",
                table: "Files");
        }
    }
}
