using Microsoft.EntityFrameworkCore.Migrations;

namespace RESTSqLite.DAL.Migrations
{
    public partial class AddNameToFolder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Folders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Folders");
        }
    }
}
