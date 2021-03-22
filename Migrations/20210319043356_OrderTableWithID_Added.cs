using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MyResourcesApp.Migrations
{
    public partial class OrderTableWithID_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "orderInfo");

            migrationBuilder.AddColumn<char>(
                       name: "OrderStatusID",
                     table: "orderInfo");

            migrationBuilder.AddColumn<int>(
                name: "OrderID",
                table: "orderInfo",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderInfo",
                table: "orderInfo",
                column: "OrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_orderInfo",
                table: "orderInfo");

            migrationBuilder.DropColumn(
                name: "OrderID",
                table: "orderInfo");

            migrationBuilder.RenameTable(
                name: "orderInfo",
                newName: "orders");

            migrationBuilder.RenameColumn(
                name: "OrderStatusID",
                table: "orders",
                newName: "OrderStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "CID");
        }
    }
}
