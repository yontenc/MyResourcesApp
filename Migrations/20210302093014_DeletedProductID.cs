using Microsoft.EntityFrameworkCore.Migrations;

namespace MyResourcesApp.Migrations
{
    public partial class DeletedProductID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "product");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "product",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
