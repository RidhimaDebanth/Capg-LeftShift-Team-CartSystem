using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShoppingCartSystem.Migrations
{
    public partial class UpdatedCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CategoryImage",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryImage",
                table: "Categories");
        }
    }
}
