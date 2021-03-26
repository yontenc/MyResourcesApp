using Microsoft.EntityFrameworkCore.Migrations;

namespace MyResourcesApp.Migrations
{
    public partial class OrderStatusNameNSiteNameAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "order",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderStatusName",
                table: "order",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SiteName",
                table: "order",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "order");

            migrationBuilder.DropColumn(
                name: "OrderStatusName",
                table: "order");

            migrationBuilder.DropColumn(
                name: "SiteName",
                table: "order");
        }
    }
}
